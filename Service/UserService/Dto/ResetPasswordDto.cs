using System.ComponentModel.DataAnnotations;

namespace Services.UserService.Dto
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$",
            ErrorMessage = "Password must have 1 UpperCase, 1LowerCase, 1 Number, 1 non Alphanumeric and at least 6 character")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
