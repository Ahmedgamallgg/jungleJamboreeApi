using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.BirthdayService.Service.Dtos;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class BirthdayController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BirthdayController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var birthdays = await _unitOfWork.Reposatory<BirthdayParty>().GetAllAsync();
            var mapper = _mapper.Map<IReadOnlyList<BirthdayViewModel>>(birthdays);
            return View(mapper);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var birthdays = await _unitOfWork.Reposatory<BirthdayParty>().GetByAsynsc(id);
            var mapper = _mapper.Map<BirthdayViewModel>(birthdays);

            return View(mapper);



        }


        public async Task<IActionResult> Delete(int id)
        {
            var birthdays = await _unitOfWork.Reposatory<BirthdayParty>().GetByAsynsc(id);
            _unitOfWork.Reposatory<BirthdayParty>().Delete(birthdays);
            await _unitOfWork.Complete();

            return RedirectToAction("Index");

        }



    }
}
