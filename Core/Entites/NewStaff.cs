using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Core.Entites
{
    public class NewStaff : BaseEntity
    {
        public string UserId { get; set; }
        public Users User { get; set; }
        public int RequestId { get; set; }
        public Requests Request { get; set; }

        public string PictureUrl { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string CVUrl { get; set; }
        public DateOfBirth DOB { get; set; }

        [Phone]
        public string phone { get; set; }

        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
