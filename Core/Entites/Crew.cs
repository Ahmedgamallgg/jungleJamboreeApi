using Core.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class Crew : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SSN { get; set; }

        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Position { get; set; }

        public int WorkHours { get; set; }

        public string Discriminator { get; set; }

        public int CampId { get; set; }
        public Camp Camp { get; set; }
        public int PartyId { get; set; }
        public BirthdayParty Party { get; set; }

        public ICollection<CrewLocation> CrewLocations { get; set; }
        public ICollection<CrewSkills> CrewSkills { get; set; }


    }
}
