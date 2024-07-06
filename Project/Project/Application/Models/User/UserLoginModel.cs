using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.User
{
    public class UserLoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [PasswordValidation]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
