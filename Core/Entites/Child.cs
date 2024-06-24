using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Core.Entites
{

    public class Child : BaseEntity
    {
      
        public int Id { get; set; }

        public DateOfBirth DOB { get; set; }

        [MaxLength(10)]
        public string FName { get; set; }

        [MaxLength(10)]
        public string Lname { get; set; }
        [Phone]
        [MaxLength(13)]
        public string EmergencyContact { get; set; }
        public Gender Gender { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }
        public ICollection<BirthdayParty> BirthdayParty { get; set; }
        public ChildCamp ChildCamp { get; set; }

        public ICollection<ChildAllergis> ChildAllergis { get; set; }
        public ICollection<ChildMedicalConditions> ChildMedicalConditions { get; set; }


    }
}
