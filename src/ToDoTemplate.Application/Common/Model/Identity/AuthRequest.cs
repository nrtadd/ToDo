using System.ComponentModel.DataAnnotations;

namespace ToDoTemplate.Application.Common.Model.Identity
{
    public class AuthRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
