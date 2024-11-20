using System.ComponentModel.DataAnnotations;

namespace Sakanatcom.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email Address Is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Is Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
