using System.ComponentModel.DataAnnotations;

namespace Service.ChildService.Services.Dtos
{
    public class ChildMedicalConditionViewModel
    {
        [MaxLength(10)]
        [Required]
        public string FName { get; set; }

        [MaxLength(10)]
        [Required]

        public string Lname { get; set; }

        public ICollection<ChildMedicalConditionDto> MedicalCondition { get; set; }
    }
}
