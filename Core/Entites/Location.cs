using Core.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class Location :BaseEntity
    {
        public int Id { get; set; }

        [Phone]
        public string Phone{ get; set; }
        public string Address { get; set; }
        [Column(TypeName ="money")]
        public decimal RentalFees { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public ICollection<CrewLocation> CrewLocations { get; set; }

        public Camp Camp { get; set; }

    }
}
