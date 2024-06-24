using Core.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class CrewLocation
    {
        [ForeignKey(nameof(Crew))]
        public long SSN { get; set; }
        public Crew Crew { get; set; }
        public int LocationId { get; set;}
        public Location Location { get; set; }
    }
}
