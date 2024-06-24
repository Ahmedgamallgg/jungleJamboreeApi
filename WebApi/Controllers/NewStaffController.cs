using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.NewStaffService.Interface;
using Service.NewStaffService.Service.Dtos;
using System.Security.Claims;
using WebApi.HandelResponses;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]

    public class NewStaffController : BaseController
    {
        private readonly INewStaffService _newStaffService;

        public NewStaffController(INewStaffService newStaffService)
        {
            _newStaffService = newStaffService;
        }
        [HttpPost]

        public async Task<ActionResult> ApplyNewStaff([FromForm]NewStaffDto staffDto)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            if (staffDto.CV is null || staffDto.Picture is null)
                return BadRequest(new ApiResponse(400, "You Have to add CV and Picture To Continue"));

            staffDto.PictureUrl = DocumentSettings.UploadFile(staffDto.Picture, "Pictures");
            staffDto.CVUrl = DocumentSettings.UploadFile(staffDto.CV, "CVs");



            var result = await _newStaffService.ApplyNewStaff(staffDto, email);
            if(result)
                return Ok(new ApiResponse(200, "You Have Applied successfuly"));

            return Ok(new ApiResponse(200, "You Have Applied Before and Waiting for review"));
        }

    }
}
