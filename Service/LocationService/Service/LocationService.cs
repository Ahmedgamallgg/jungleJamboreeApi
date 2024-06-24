using AutoMapper;
using Core.Entites;
using Infrastracture.Interfaces;
using Service.LocationService.Interface;
using Service.LocationService.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LocationService.Service
{
    public class LocationService : IlocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<LocationDto>> GetAllLocationsAsync()
        {
            var locations = await _unitOfWork.Reposatory<Location>().GetAllAsync();
            
            var mappedLocation = _mapper.Map<IReadOnlyList<LocationDto>>(locations);

            return mappedLocation;
           
        }

        public async Task<LocationDto> GetLocationById(int id)
        {
            var location = await _unitOfWork.Reposatory<Location>().GetByAsynsc(id);

            var mappedLocation = _mapper.Map<LocationDto>(location);

            return mappedLocation;
        }
    }
}
