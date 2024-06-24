using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class CrewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrewController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var crews = await _unitOfWork.Reposatory<Crew>().GetAllAsync();
            var mappedcrews = _mapper.Map<IReadOnlyList<CrewViewModel>>(crews);
            return View(mappedcrews);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View(new CrewViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrewViewModel crewViewModel)
        {
            if (!ModelState.IsValid)
            {
 

                return View(crewViewModel);
            }
            var crew = _mapper.Map<Crew>(crewViewModel);
            await _unitOfWork.Reposatory<Crew>().Add(crew);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(long id)
        {
            var crew = await _unitOfWork.Reposatory<Crew>().GetByAsynsc(id);
            var crewViewModel = _mapper.Map<CrewViewModel>(crew);

            return View(crewViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CrewViewModel crewViewModel)
        {
            if (!ModelState.IsValid)
            {


                return View(crewViewModel);
            }
            var crew = _mapper.Map<Crew>(crewViewModel);
            _unitOfWork.Reposatory<Crew>().Update(crew);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var crew = await _unitOfWork.Reposatory<Crew>().GetByAsynsc(id);
            var mappedcrew= _mapper.Map<CrewViewModel>(crew);
            return View(mappedcrew);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var crew = await _unitOfWork.Reposatory<Crew>().GetByAsynsc(id);
            _unitOfWork.Reposatory<Crew>().Delete(crew);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");

        }


    }
}
