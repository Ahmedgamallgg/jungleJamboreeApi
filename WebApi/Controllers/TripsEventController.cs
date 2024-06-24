using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.TripsEventService.Interface;
using Service.TripsEventService.Service.Dtos;
using System.Security.Claims;
using WebApi.HandelResponses;

namespace WebApi.Controllers
{
    [Authorize]
    public class TripsEventController : BaseController
    {
        private readonly ITripsEventService _tripsEventService;

        public TripsEventController(ITripsEventService tripsEventService)
        {
            _tripsEventService = tripsEventService;
        }
        [HttpPost]
        public async Task<ActionResult> ApplyTripsEvent(TripsEventDto tripsEventDto)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);
            if (email == null)
                return BadRequest("Please Sign In And Try Again");
            await _tripsEventService.ApplyTripsEvent(tripsEventDto, email);
            return Ok(new ApiResponse(200, "You Have Applied successfuly"));
        }

    }
}
