using System.ComponentModel.DataAnnotations;

namespace Application.Models.User
{
    public class UserRequestModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [PasswordValidation]
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PersonalNumber { get; set; } = string.Empty;
    }
}
