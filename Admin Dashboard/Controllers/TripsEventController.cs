using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using dmin_Dashboard.Helpers;
using Infrastracture.Interfaces;
using Infrastracture.Specification.RequestSpecifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Hepler;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class TripsEventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        private readonly UserManager<Users> _userManager;

        public TripsEventController(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, UserManager<Users> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;

            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var tripsEvent = await _unitOfWork.Reposatory<TripsEvents>().GetAllAsync();
            var mappedTripsEvent = _mapper.Map<IReadOnlyList<TripsEventViewModel>>(tripsEvent);
            return View(mappedTripsEvent);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var specs = new RequestSpecifications(id);
            var request = await _unitOfWork.Reposatory<Requests>().GetByIdWithSpecificationsAsync(specs);
            var mappedTripsEvent = _mapper.Map<TripsEventViewModel>(request.TripsEvents.FirstOrDefault());
            return View(mappedTripsEvent);


        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _unitOfWork.Reposatory<Requests>().GetByAsynsc(id);
            _unitOfWork.Reposatory<Requests>().Delete(request);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Accept(int id)
        {
            var specs = new RequestSpecifications(id);
            var request = await _unitOfWork.Reposatory<Requests>().GetByIdWithSpecificationsAsync(specs);
            request.TripsEvents.FirstOrDefault().State = RequestType.Approved;
            _unitOfWork.Reposatory<Requests>().Update(request);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(SendApprovelEmail), request.TripsEvents.FirstOrDefault());
        }
        public async Task<IActionResult> SendApprovelEmail(TripsEvents tripsEvents)
        {
            var user = await _userManager.FindByIdAsync(tripsEvents.UserId);
            var emailAddress = new Email()
            {
                To = user.Email,
                Subject = "Trip Or Event Approval",
                Body = $"Hi {user.FName},\n\nGreat news! Your booking for the trip or event has been successfully confirmed. Get ready for an unforgettable adventure with us. We can’t wait to see you there and make amazing memories together!\n\nIf you have any questions or need further assistance, feel free to contact us at any time.\n\nSee you soon!\n\nBest regards,\nJungle jamboree Team"
            };

            var result = _emailService.SendEmail(emailAddress);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Reject(int id)
        {
            var specs = new RequestSpecifications(id);
            var request = await _unitOfWork.Reposatory<Requests>().GetByIdWithSpecificationsAsync(specs);
            request.TripsEvents.FirstOrDefault().State = RequestType.Reject;
            _unitOfWork.Reposatory<Requests>().Update(request);
            await _unitOfWork.Complete();
            return RedirectToAction("Index");
        }



    }
}
