using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Admin_Dashboard.Models
{
    public class NewStaffViewModel
    {
        public string UserId { get; set; }

        public int RequestId { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [Phone]
        public string phone { get; set; }

        public Gender Gender { get; set; }
        public DateOfBirth DOB { get; set; } 
        public string PictureUrl { get; set; }


        public string CVUrl { get; set; }


    }
}
