using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Infrastracture.Specification.CampSpecifications;
using Service.CampService.Interface;
using Service.CampService.Service.Dtos;

namespace Service.CampService.Service
{
    public class CampService : ICampService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CampService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<CampDto>> GetAllCamps()
        {
            var specs = new CampWithLocationSpecs();
            var camps = await _unitOfWork.Reposatory<Camp>().GetAllWithSpecificationsAsync(specs);
            var campdto = _mapper.Map<IReadOnlyList<CampDto>>(camps);
            return campdto;
        }

        public async Task<CampDto> GetCampById(int id)
        {
            var specs = new CampWithLocationSpecs(id);
            var camps = await _unitOfWork.Reposatory<Camp>().GetByIdWithSpecificationsAsync(specs);
            var campdto = _mapper.Map<CampDto>(camps);
            return campdto;
        }
    }
}
