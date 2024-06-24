using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Identity;
using Service.NewStaffService.Interface;
using Service.NewStaffService.Service.Dtos;

namespace Service.NewStaffService.Service
{
    public class NewStaffService : INewStaffService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Users> _userManager;

        public NewStaffService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<Users> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> ApplyNewStaff(NewStaffDto staffDto, string email)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                var newStaff = _mapper.Map<NewStaff>(staffDto);
                newStaff.UserId = user.Id;
                var request = new Requests();
                request.NewStaff = new List<NewStaff>();
                request.NewStaff.Add(newStaff);
                await _unitOfWork.Reposatory<Requests>().Add(request);
                await _unitOfWork.Complete();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}
