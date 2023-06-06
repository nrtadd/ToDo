using ToDoTemplate.Application.Common.Model.Identity;

namespace ToDoTemplate.Application.Common.Interfaces
{
    public interface IAppUserService
    {
        Task<AuthResponse> RegistrationAsync(RegistrationRequest request);
        Task<AuthResponse> AuthenticateAsync(AuthRequest request);
        Task<AuthResponse> AuthenticateAsync(AuthwithRefreshRequest request);


    }
}
