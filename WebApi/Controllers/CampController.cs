using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.CampService.Interface;
using Service.CampService.Service.Dtos;
using WebApi.Helper;

namespace WebApi.Controllers
{

    public class CampController : BaseController
    {
        private readonly ICampService _campService;

        public CampController(ICampService campService)
        {
            _campService = campService;
        }
        [Cashe(86400)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CampDto>>> GetAllCamps()
        {
            var camps = await _campService.GetAllCamps();
            return Ok(camps);
        }
        [HttpGet]
        [Cashe(7200)]

        public async Task<ActionResult<CampDto>> GetCampById(int id) 
        {
            var camp = await _campService.GetCampById(id);
            return Ok(camp);
        }


    }
}
