namespace ToDoTemplate.Application.Common.Model.Identity
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string JWToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
