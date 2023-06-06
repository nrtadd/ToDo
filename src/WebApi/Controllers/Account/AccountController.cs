using Microsoft.AspNetCore.Mvc;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.Common.Model.Identity;

namespace WebApi.Controllers.Account
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AccountController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AuthenticateAsync(AuthRequest request)
        {
            return Ok(await _appUserService.AuthenticateAsync(request));
        }
        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AuthenticateAsyncRefresh(AuthwithRefreshRequest request)
        {
            return Ok(await _appUserService.AuthenticateAsync(request));
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(RegistrationRequest request)
        {
            var f = await _appUserService.RegistrationAsync(request);
            return Ok(f);
        }

    }
}
