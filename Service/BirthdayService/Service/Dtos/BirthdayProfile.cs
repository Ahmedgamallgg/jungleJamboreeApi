using AutoMapper;
using Core.Entites;

namespace Service.BirthdayService.Service.Dtos
{
    public class BirthdayProfile : Profile
    {
        public BirthdayProfile() 
        {
            CreateMap<BirthdayParty, BirthdayDto>().ReverseMap();
        }
    }
}
