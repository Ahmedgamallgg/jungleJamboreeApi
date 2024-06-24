using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Infrastracture.Specification.ChildSpecifications;
using Microsoft.AspNetCore.Identity;
using Service.BirthdayService.Interface;
using Service.BirthdayService.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BirthdayService.Service
{
    public class BirthdayService : IBirthdayService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Users> _userManager;

        public BirthdayService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<Users> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task CreateBirthday(BirthdayDto birthdayDto, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var specs = new ChildWithMedicalAndAllergisSpecs(user.Id);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            var birthday = _mapper.Map<BirthdayParty>(birthdayDto);
            birthday.ChildId = child.Id;
            await _unitOfWork.Reposatory<BirthdayParty>().Add(birthday);
            await _unitOfWork.Complete();
        }
    }
}
