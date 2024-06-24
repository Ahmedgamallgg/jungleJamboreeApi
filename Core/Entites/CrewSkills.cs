using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites
{
    public class CrewSkills
    {
        [ForeignKey(nameof(Crew))]
        public long SSN { get; set; }
        public Crew Crew { get; set; }
        public string Skills { get; set;}
    }
}
