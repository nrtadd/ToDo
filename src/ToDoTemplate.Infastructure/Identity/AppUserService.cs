using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.Common.Model.Identity;

namespace ToDoTemplate.Infastructure.Identity
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;


        public AppUserService
            (UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<AuthResponse> RegistrationAsync(RegistrationRequest request)
        {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.Email,

            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new IdentityExceptions(String.Concat(result.Errors.Select(x=>x.Description)));
            }
            var findUser = await _userManager.FindByEmailAsync(request.Email);
            await _userManager.AddClaimAsync(findUser, new Claim(Roles.Client.ToString(), true.ToString()));
            return await AuthenticateAsync(new AuthRequest { Email = request.Email, Password = request.Password });

        }
        public async Task<AuthResponse> AuthenticateAsync(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || String.IsNullOrEmpty(request.Password))
            {
                throw new IdentityExceptions("Invalid data");
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!result.Succeeded)
            {
                throw new IdentityExceptions("Invalid data");
            }
            return await GeneratorAuthResponse(user);
        }
        //refresh
        public async Task<AuthResponse> AuthenticateAsync(AuthwithRefreshRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || (user.RefreshToken != request.RefreshToken) || request.RefreshToken == null)
            {
                throw new IdentityExceptions("Invalid data");
            }

            return await GeneratorAuthResponse(user);
        }
        private async Task<AuthResponse> GeneratorAuthResponse(AppUser user)
        {
            AuthResponse response = new AuthResponse();
            var Refresh = GetRefreshToken();
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            user.RefreshToken = Refresh;
            _userManager.UpdateAsync(user);
            response.UserId = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.RefreshToken = Refresh;
            return response;
        }
        private string GetRefreshToken()
        {
            var bytes = new byte[40];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(bytes);
            }
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        private async Task<JwtSecurityToken> GenerateJWToken(AppUser user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            double expires = Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"]);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expires),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }



    }
}
