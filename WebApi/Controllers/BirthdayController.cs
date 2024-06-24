using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.BirthdayService.Interface;
using Service.BirthdayService.Service.Dtos;
using System.Security.Claims;
using WebApi.HandelResponses;

namespace WebApi.Controllers
{
    [Authorize]

    public class BirthdayController : BaseController
    {
        private readonly IBirthdayService _birthdayService;

        public BirthdayController(IBirthdayService birthdayService) 
        {
            _birthdayService = birthdayService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBirthday(BirthdayDto birthdayDto)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            await _birthdayService.CreateBirthday(birthdayDto, email);
            return Ok(new ApiResponse(200, "BirthdayParty is Submitted successfuly"));

        }


    }
}
