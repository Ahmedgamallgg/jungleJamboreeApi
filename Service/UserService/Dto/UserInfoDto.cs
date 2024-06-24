using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Service.UserService.Dto
{
    public class UserInfoDto
    {
        [Required]
        [MaxLength(10)]
        public string FName { get; set; }

        [MaxLength(10)]
        [Required]

        public string Lname { get; set; }
        [Required]

        public Gender Gender { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public DateOfBirth DOB { get; set; }

    }
    public class UserInfoResultDto
    {
        [Required]
        [MaxLength(10)]
        public string FName { get; set; }

        [MaxLength(10)]
        [Required]

        public string Lname { get; set; }
        [Required]

        public Gender Gender { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public DateOfBirth DOB { get; set; }

        public string? OldPassword { get; set; }


        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$",
             ErrorMessage = "Password must have 1 UpperCase, 1LowerCase, 1 Number, 1 non Alphanumeric and at least 6 character")]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password Mismatch")]
        public string? ConfirmPassword { get; set; }
    }
}
