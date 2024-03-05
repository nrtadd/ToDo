using System.Security.Claims;
using ToDoTemplate.Application.Common.Interfaces;

namespace WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string UserId { get => _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;}
    }
}
