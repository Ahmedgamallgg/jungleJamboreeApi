using AutoMapper;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LocationService.Service.Dto
{
    public class LocationProfile : Profile
    {
        public LocationProfile() {
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
