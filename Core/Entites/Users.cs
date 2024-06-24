
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entites
{
    public enum Gender : byte
    {
        male =1,
        female =2,
        m =1,
        f =2
    }
    public class Users : IdentityUser
    {
       


        [MaxLength(10)]
        public string FName{ get; set; }

        [MaxLength(10)]
        public string Lname { get; set; }


        public Gender Gender { get; set; }

        public string Address { get; set; }

        public DateOfBirth DOB { get; set; }
        public NewStaff NewStaff { get; set; }

        public ICollection<Child> Childrens { get; set; }


    }

}
