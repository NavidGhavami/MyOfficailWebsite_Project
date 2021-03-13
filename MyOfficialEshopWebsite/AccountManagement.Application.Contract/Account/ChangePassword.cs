using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace AccountManagement.Application.Contract.Account
{
    public class ChangePassword
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = ApplicationMessages.DuplicatedPassword)]
        public string RePassword { get; set; }
    }
}