using System.ComponentModel.DataAnnotations;

namespace Service.ChildService.Services.Dtos
{
    public class ChildMedicalConditionDto
    {
        public int ChildId { get; set; }
        [Required]
        public string MedicalConditions { get; set; }
        [Required]

        public string MedicalConditionsDescreption { get; set; }
    }
}
