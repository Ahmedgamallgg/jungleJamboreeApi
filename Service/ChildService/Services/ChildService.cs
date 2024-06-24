using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Infrastracture.Specification.ChildSpecifications;
using Microsoft.AspNetCore.Identity;
using Service.ChildService.Interface;
using Service.ChildService.Services.Dtos;

namespace Service.ChildService.Services
{
    public class ChildService : IChildService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<Users> _userManager;

        public ChildService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Users> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> AddAllergisAsync(ChildAllergisDto childAllergis)
        {
            var specs = new ChildWithAllergisSpecification(childAllergis.ChildId);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            var childall = _mapper.Map<ChildAllergis>(childAllergis);
            child.ChildAllergis.Add(childall);
            _unitOfWork.Reposatory<Child>().Update(child);
            await _unitOfWork.Complete();

            return true;

        }

        public async Task<bool> AddChild(ChildResultDto childDto, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var child = _mapper.Map<Child>(childDto);
            if (child == null) return false;
            child.UserId = user.Id;
            await _unitOfWork.Reposatory<Child>().Add(child);
            await _unitOfWork.Complete();

            return true;
            
        }

        public async Task<int> AddChildToCampAsync(ChildCampDto childCampDto)
        {
            var specs = new CHildWIthCampSpecs(childCampDto.ChildId);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            if(child.ChildCamp != null)
                if(child.ChildCamp.CampId == childCampDto.CampId) 
                    return -1;
            var camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(childCampDto.CampId);
            if(camp.IsActive == false) 
                return 0;
            var childcamp = _mapper.Map<ChildCamp>(childCampDto);
            child.ChildCamp = childcamp;
            _unitOfWork.Reposatory<Child>().Update(child);
            await _unitOfWork.Complete();

            return 1;
        }

        public async Task<bool> AddMedicalConditionAsync(ChildMedicalConditionDto childAllergis)
        {
            var specs = new ChildWithMedicalContitionSpecification(childAllergis.ChildId);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            var childall = _mapper.Map<ChildMedicalConditions>(childAllergis);
            child.ChildMedicalConditions.Add(childall);
            _unitOfWork.Reposatory<Child>().Update(child);
            await _unitOfWork.Complete();

            return true;

        }

        public async Task<bool> DeleteAllergisAsync(ChildAllergisDto childAllergis)
        {
            var child = _mapper.Map<ChildAllergis>(childAllergis);
            if (child == null) return false;

            _unitOfWork.Reposatory<ChildAllergis>().Delete(child);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<bool> DeleteChildAsync(int id)
        {
            var child = await _unitOfWork.Reposatory<Child>().GetByAsynsc(id);
            if (child == null) return false;
            
            _unitOfWork.Reposatory<Child>().Delete(child);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<bool> DeleteChildFromCamp(ChildCampDto childCampDto)
        {
            try
            {
                var childcamp = _mapper.Map<ChildCamp>(childCampDto);
                _unitOfWork.Reposatory<ChildCamp>().Delete(childcamp);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }

        public async Task<bool> DeleteMedicalConditionAsync(ChildMedicalConditionDto childAllergis)
        {
            var child = _mapper.Map<ChildMedicalConditions>(childAllergis);
            if (child == null) return false;

            _unitOfWork.Reposatory<ChildMedicalConditions>().Delete(child);
            await _unitOfWork.Complete();

            return true;
        }

        public async Task<ChildAllergisViewModel> GetChildAllergisByIdAsync(int id, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var specs = new ChildWithAllergisSpecification(id, user.Id);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            if (child == null)
                throw new Exception("Child Not Found");
            var childDto = _mapper.Map<ChildAllergisViewModel>(child);
            return childDto;
        }

        public async Task<ChildDetailsDto> GetChildByIdAsync(int id, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var specs = new ChildWithMedicalAndAllergisSpecs(id,user.Id);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            if (child == null)
                throw new Exception("Child Not Found");
            var childDto = _mapper.Map<ChildDetailsDto>(child);

            var camp = new Camp();
            if (child.ChildCamp != null)
            {
                camp = await _unitOfWork.Reposatory<Camp>().GetByAsynsc(child.ChildCamp.CampId);
            }
                childDto.CampName = camp?.Description ?? "Not in a Camp";
            return childDto;
            

        }

        public async Task<ChildMedicalConditionViewModel> GetChildMedicalConditionsByIdAsync(int id, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var specs = new ChildWithMedicalContitionSpecification(id, user.Id);
            var child = await _unitOfWork.Reposatory<Child>().GetByIdWithSpecificationsAsync(specs);
            if (child == null)
                throw new Exception("Child Not Found");
            var childDto = _mapper.Map<ChildMedicalConditionViewModel>(child);
            return childDto;
        }

        public async Task<ICollection<ChildDto>> GetChildrenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("Please Login First");
            var specs = new ChildWithMedicalAndAllergisSpecs(user.Id);
            var childern = await _unitOfWork.Reposatory<Child>().GetAllWithSpecificationsAsync(specs);
            
            if (childern == null)
                throw new Exception("No Childern Found");
            var childernDto = _mapper.Map<ICollection<ChildDto>>(childern);
            return childernDto;
        }

        public async Task<bool> UpdateChildAsync(ChildDto childDto,string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("Please Login First");

            var child = _mapper.Map<Child>(childDto);
            if (child == null) return false;
            child.UserId = user.Id;
            _unitOfWork.Reposatory<Child>().Update(child);
            await _unitOfWork.Complete();

            return true;
        }
    }
}
