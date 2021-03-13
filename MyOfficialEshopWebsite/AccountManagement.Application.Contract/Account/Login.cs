using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class Login
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
    }
}