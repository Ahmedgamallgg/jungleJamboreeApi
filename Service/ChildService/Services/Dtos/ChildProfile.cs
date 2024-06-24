using AutoMapper;
using Core.Entites;

namespace Service.ChildService.Services.Dtos
{
    public class ChildProfile : Profile
    {
        public ChildProfile()
        {
            CreateMap<ChildCamp, ChildCampDto>().ReverseMap();
            CreateMap<Child, ChildResultDto>().ReverseMap();

            CreateMap<ChildDto, Child>();

            CreateMap<Child, ChildDto>()
                .ForMember(c => c.CampId, options => options.MapFrom(C => C.ChildCamp.CampId));
            CreateMap<ChildAllergis, ChildAllergisDto>().ReverseMap();
            CreateMap<ChildMedicalConditions, ChildMedicalConditionDto>().ReverseMap();
            CreateMap<Child, ChildAllergisViewModel>()
                .ForMember(c => c.Allergis, options => options.MapFrom(c => c.ChildAllergis.Select(s => new ChildAllergisDto
                {
                    ChildId = s.ChildId,
                    Allergies = s.Allergies,
                    AllergiesDescreption = s.AllergiesDescreption,
                }).ToList()));
            CreateMap<Child, ChildMedicalConditionViewModel>()
                .ForMember(c =>c.MedicalCondition, options => options.MapFrom(c => c.ChildMedicalConditions.Select( s => new ChildMedicalConditionDto
                {
                    ChildId = s.ChildId,
                    MedicalConditions = s.MedicalConditions,
                    MedicalConditionsDescreption = s.MedicalConditionsDescreption
                    
                }).ToList()));



            CreateMap<Child, ChildDetailsDto>()
                .ForMember(c => c.Allergies, options => options.MapFrom(c => c.ChildAllergis.Select(s => s.Allergies)))
                .ForMember(c => c.MedicalConditions, options => options.MapFrom(c => c.ChildMedicalConditions.Select(s => s.MedicalConditions)))
                .ForMember(c => c.ParentName, options => options.MapFrom(c => c.User.FName));





        }
    }
}
