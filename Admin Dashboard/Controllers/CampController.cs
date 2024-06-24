using Admin_Dashboard.Models;
using Admin_Dashboard.Repo.CampRepo;
using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Infrastracture.Specification.CampSpecifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.CampService.Service.Dtos;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class CampController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICampRepo _campRepo;

        public CampController(IUnitOfWork unitOfWork, IMapper mapper, ICampRepo campRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _campRepo = campRepo;
        }
        public async Task<IActionResult> Index()
        {
            var camps = await _unitOfWork.Reposatory<Camp>().GetAllAsync();
            var mappedCamps = _mapper.Map<IReadOnlyList<CampDto>>(camps);
            return View(mappedCamps);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Locations = await _unitOfWork.Reposatory<Location>().GetAllAsync();
            return View(new CampViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CampViewModel campViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locations = await _unitOfWork.Reposatory<Location>().GetAllAsync();

                return View(campViewModel);
            }
            var camp = _mapper.Map<Camp>(campViewModel);
            await _unitOfWork.Reposatory<Camp>().Add(camp);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            var camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(id);
            var campViewModel = _mapper.Map<CampViewModel>(camp);
            ViewBag.Locations = await _unitOfWork.Reposatory<Location>().GetAllAsync();
            return View(campViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CampViewModel campViewModel)
        {
            if (!ModelState.IsValid) {
                 ViewBag.Locations = await _unitOfWork.Reposatory<Location>().GetAllAsync();

                return View(campViewModel);
            }
            var camp = _mapper.Map<Camp>(campViewModel);
            _unitOfWork.Reposatory<Camp>().Update(camp);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var specs = new CampWithLocationSpecification(id);
            var camp = await _unitOfWork.Reposatory<Camp>().GetByIdWithSpecificationsAsync(specs);
            var mappedCamp = _mapper.Map<CampDto>(camp);
            return View(mappedCamp);

        }


        public async  Task<IActionResult> Delete(int id)
        {
            var camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(id);
            _unitOfWork.Reposatory<Camp>().Delete(camp);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }
        
        public async Task<IActionResult> IsActive(int id)
        {
            var camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(id);
            camp.IsActive = !camp.IsActive;
            if (camp.IsActive == false)
            {
                _campRepo.DeleteCampChild(camp.Id);
            }
            _unitOfWork.Reposatory<Camp>().Update(camp);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }

    

    }
}
