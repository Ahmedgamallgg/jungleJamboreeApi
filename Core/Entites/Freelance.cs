using System.ComponentModel.DataAnnotations;

namespace Core.Entites
{
    public class Freelance :Crew
    {
        
        public double HourRate { get; set; }

        [MaxLength(50)]
        public string Feedback { get; set; }

        
    }
}
