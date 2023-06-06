using System.ComponentModel.DataAnnotations;

namespace ToDoTemplate.Application.Common.Model.Identity
{
    public class AuthwithRefreshRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
