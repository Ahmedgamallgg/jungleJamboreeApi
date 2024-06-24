using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Identity;
using Service.TripsEventService.Interface;
using Service.TripsEventService.Service.Dtos;


namespace Service.TripsEventService.Service
{
    public class TripsEventService : ITripsEventService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Users> _userManager;

        public TripsEventService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<Users> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task ApplyTripsEvent(TripsEventDto tripsEventDto,string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tripsevent = _mapper.Map<TripsEvents>(tripsEventDto);
            tripsevent.UserId = user.Id;
            var request = new Requests();
            request.TripsEvents = new List<TripsEvents>();

            request.TripsEvents.Add(tripsevent);
            await _unitOfWork.Reposatory<Requests>().Add(request);
            await _unitOfWork.Complete();

        }
    }
}
