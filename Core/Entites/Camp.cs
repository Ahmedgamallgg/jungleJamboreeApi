using Core.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class Camp: BaseEntity
    {

        public int Id { get; set; }

        public string CampType { get; set; }

        public int Capacity { get; set; }

        [Range(4,12)]
        public int AgeRange { get; set; }

        [Column(TypeName = "Money")]
        public decimal RegistrationFees { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ChildCamp ChildCamp { get; set; }

        public ICollection<Crew> Crews { get; set; }


    }
}
