using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Infrastracture.Specification.ChildSpecifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class ChildController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChildController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var specs = new ChildWithMedicalAndAllergisSpecs();
            var childs = await _unitOfWork.Reposatory<Child>().GetAllWithSpecificationsAsync(specs);
            var mappedCHilds = _mapper.Map<IReadOnlyList<childViewModel>>(childs);
            return View(mappedCHilds);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var specs = new ChildWithMedicalAndAllergisSpecs(id);

            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            var mappedChild = _mapper.Map<childViewModel>(child);
            return View(mappedChild);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var child = await _unitOfWork.Reposatory<Child>().GetByAsynsc(id);
            _unitOfWork.Reposatory<Child>().Delete(child);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

    }
}
