using AutoMapper;
using Core.Entites;

namespace Service.CampService.Service.Dtos
{
    public class CampProfile: Profile
    {
        public CampProfile()
        {
            CreateMap<Camp, CampDto>()
                .ForMember(c => c.LocationName, options => options.MapFrom(cd => cd.Location.Name));
        }
    }
}
