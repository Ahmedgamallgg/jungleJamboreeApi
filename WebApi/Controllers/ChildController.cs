using Microsoft.AspNetCore.Mvc;
using Service.ChildService.Interface;
using Service.ChildService.Services.Dtos;
using System.Security.Claims;
using WebApi.HandelResponses;
using WebApi.Helper;

namespace WebApi.Controllers
{

    public class ChildController : BaseController
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }
        [HttpGet]
        public async Task<ActionResult<ChildAllergisViewModel>> GetChildAllergisByIdAsync(int id)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            var child = await _childService.GetChildAllergisByIdAsync(id, email);
            if (child == null)
                return NotFound(new ApiResponse(404, "Child Not Found"));



            return Ok(child);

        }
        [HttpPost]
        public async Task<IActionResult> AddAllergisAsync(ChildAllergisDto childAllergis)
        {
           var result = await _childService.AddAllergisAsync(childAllergis);
            if(result)
                return Ok(new ApiResponse(200,"Added Successfully"));

            return BadRequest("Please Try Again");
        }
        [HttpPost]

        public async Task<IActionResult> AddChild(ChildResultDto childDto)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if(email == null)
                return BadRequest("Please Sign In And Try Again");

            var result = await _childService.AddChild(childDto, email);
            if (result)
                return Ok("Added Successfully");

            return BadRequest("Please Try Again");


        }
        [HttpGet]
        public async Task<ActionResult<ChildMedicalConditionViewModel>> GetChildMedicalConditionsByIdAsync(int id)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            var child = await _childService.GetChildMedicalConditionsByIdAsync(id, email);
            if (child == null)
                return NotFound(new ApiResponse(404, "Child Not Found"));



            return Ok(child);

        }

        [HttpPost]

        public async Task<IActionResult> AddMedicalConditionAsync(ChildMedicalConditionDto childAllergis)
        {
            var result = await _childService.AddMedicalConditionAsync(childAllergis);
            if (result)
                return Ok(new ApiResponse(200, "Added Successfully"));

            return BadRequest(new ApiResponse(401, "Please Try Again"));
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteAllergisAsync(ChildAllergisDto childAllergis)
        {
            var result = await _childService.DeleteAllergisAsync(childAllergis);
            if (result)
                return Ok("Deleted Successfully");

            return BadRequest("Please Try Again");
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteChildAsync(int id)
        {
            var result = await _childService.DeleteChildAsync(id);
            if (result)
                return Ok("Deleted Successfully");

            return BadRequest("Please Try Again");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMedicalConditionAsync(ChildMedicalConditionDto childAllergis)
        {
            var result = await _childService.DeleteMedicalConditionAsync(childAllergis);
            if (result)
                return Ok("Deleted Successfully");

            return BadRequest("Please Try Again");
        }
        [HttpGet]
        public async Task<ActionResult<ChildDetailsDto>> GetChildByIdAsync(int id)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            var child = await _childService.GetChildByIdAsync(id, email);
            if (child == null)
                return NotFound(new ApiResponse(404, "Child Not Found"));

                
           

            return Ok(child);
        }

        [HttpGet]


        public async Task<ActionResult<ICollection<ChildDto>>> GetChildrenAsync()
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            var childs = await _childService.GetChildrenAsync(email);
            return Ok(childs);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateChildAsync(ChildDto childDto)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");

            var result = await _childService.UpdateChildAsync(childDto, email);
            if (result)
                return Ok("Updated Successfully");

            return BadRequest("Please Try Again");
        }

        [HttpPost]
        public async Task<IActionResult> AddChildToCamp(ChildCampDto childcampdto)
        {
            var result = await _childService.AddChildToCampAsync(childcampdto);
            if (result == 1)
                return Ok(new ApiResponse(200, "Updated Successfully"));
            if(result == -1)
                return BadRequest(new ApiResponse(200,"Already In This Camp"));

            return BadRequest(new ApiResponse(400, "This Camp is Disabled"));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteChildFromCamp(ChildCampDto childCampDto)
        {
            var result = await _childService.DeleteChildFromCamp(childCampDto);
            if (result)
                return Ok(new ApiResponse(200, "Deleted Successfully"));

            return BadRequest(new ApiResponse(200, "Aleardy Not In This Camp"));
        }






    }
}
