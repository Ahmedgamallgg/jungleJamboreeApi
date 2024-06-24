using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.LocationService.Interface;
using Service.LocationService.Service.Dto;
using WebApi.HandelResponses;

namespace WebApi.Controllers
{

    public class LocationController : BaseController
    {
        private readonly IlocationService _locationService;

        public LocationController(IlocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LocationDto>>> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            if (locations == null)
                return NotFound(new ApiResponse(404, "oops! Locations Not Found"));

            return Ok(locations);
        }
        [HttpGet]
        public async Task<ActionResult<LocationDto>> GetLocationById(int id)
        {
            var location = await _locationService.GetLocationById(id);
            if (location == null)
                return NotFound(new ApiResponse(404, "oops! Locations Not Found"));

            return Ok(location);
        }
    }
}
