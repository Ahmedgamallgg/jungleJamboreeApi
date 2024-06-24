using Core.Entites;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Service.NewStaffService.Service.Dtos
{
    public class NewStaffDto
    {

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string? PictureUrl { get; set; }

        public IFormFile Picture {  get; set; }

        public string? CVUrl { get; set; }
        public IFormFile CV { get; set; }

        public Gender Gender { get; set; }
        public DateOfBirth DOB { get; set; } = new DateOfBirth(1990, 12, 30);
        public string Address { get; set; }

        [Phone]
        public string phone { get; set; }



    }
}
