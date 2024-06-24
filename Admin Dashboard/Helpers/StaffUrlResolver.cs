using Admin_Dashboard.Models;
using AutoMapper;
using Core.Entites;
using Service.NewStaffService.Service.Dtos;

namespace Admin_Dashboard.Helpers
{

    public class StaffPictureUrlResolver : IValueResolver<NewStaff, NewStaffViewModel, string>
    {
        private readonly IConfiguration _Configuration;

        public StaffPictureUrlResolver(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string Resolve(NewStaff source, NewStaffViewModel destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
                return _Configuration["BaseUrl"] + source.PictureUrl;

            
            return null;
        }
    }
    public class StaffCVUrlResolver : IValueResolver<NewStaff, NewStaffViewModel, string>
    {
        private readonly IConfiguration _Configuration;

        public StaffCVUrlResolver(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string Resolve(NewStaff source, NewStaffViewModel destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.CVUrl))
                return _Configuration["BaseUrl"] + source.CVUrl;


            return null;
        }
    }
}
