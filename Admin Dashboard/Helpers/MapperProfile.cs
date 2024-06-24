using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using Service.ChildService.Services.Dtos;

namespace Admin_Dashboard.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Camp, CampViewModel>().ReverseMap();
            CreateMap<NewStaff, NewStaffViewModel>().ReverseMap();

            CreateMap<NewStaff, NewStaffViewModel>()
                .ForMember(pd => pd.PictureUrl, options => options.MapFrom<StaffPictureUrlResolver>())
                .ForMember(pd => pd.CVUrl, options => options.MapFrom<StaffCVUrlResolver>());
            


            CreateMap<BirthdayParty, BirthdayViewModel>().ReverseMap();


            CreateMap<TripsEvents, TripsEventViewModel>().ReverseMap();

            CreateMap<Child, childViewModel>()
               .ForMember(c => c.Allergies, options => options.MapFrom(c => c.ChildAllergis.Select(s => s.Allergies)))
               .ForMember(c => c.MedicalConditions, options => options.MapFrom(c => c.ChildMedicalConditions.Select(s => s.MedicalConditions)))
               .ForMember(c => c.ParentName, options => options.MapFrom(c => c.User.FName));

            CreateMap<Location, LocationViewModel>()
                .ForMember(l => l.CampName, options => options.MapFrom(l => l.Camp.Description))
                .ForMember(l => l.Type, options => options.MapFrom(l => l.Discriminator))
                .ForMember(l => l.Crews, options => options.MapFrom(l => l.CrewLocations.Where(p => p.LocationId == l.Id).Select(c => c.SSN)));

            CreateMap<LocationViewModel, Location>()
                .ForMember(l => l.Discriminator, options => options.MapFrom(l => l.Type));



            CreateMap<Crew, CrewViewModel>()
                .ForMember(l => l.Type, options => options.MapFrom(l => l.Discriminator)).ReverseMap();





        }
    }
}
