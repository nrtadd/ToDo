using Microsoft.AspNetCore.Identity;

namespace ToDoTemplate.Infastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
    }
}
