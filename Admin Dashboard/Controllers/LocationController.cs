using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Infrastracture.Specification.LocationSpecifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class LocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var specs = new LocationWIthCampSpecs();
            var locations = await _unitOfWork.Reposatory<Location>().GetAllWithSpecificationsAsync(specs);
            var mappedLocations = _mapper.Map<IReadOnlyList<LocationViewModel>>(locations);
            return View(mappedLocations);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var specs = new LocationWIthCampSpecs(id);
            var locations = await _unitOfWork.Reposatory<Location>().GetByIdWithSpecificationsAsync(specs);
            var mappedLocations = _mapper.Map<LocationViewModel>(locations);
            return View(mappedLocations);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var locations = await _unitOfWork.Reposatory<Location>().GetByAsynsc(id);
            _unitOfWork.Reposatory<Location>().Delete(locations);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new LocationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel locationViewModel)
        {
            if (!ModelState.IsValid)
            {


                return View(locationViewModel);
            }
            var location = _mapper.Map<Location>(locationViewModel);
            await _unitOfWork.Reposatory<Location>().Add(location);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            var location = await _unitOfWork.Reposatory<Location>().GetByAsynsc(id);
            var locationViewModel = _mapper.Map<LocationViewModel>(location);

            return View(locationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LocationViewModel locationViewModel)
        {
            if (!ModelState.IsValid)
            {


                return View(locationViewModel);
            }
            var location = _mapper.Map<Location>(locationViewModel);
            _unitOfWork.Reposatory<Location>().Update(location);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }

    }
}
