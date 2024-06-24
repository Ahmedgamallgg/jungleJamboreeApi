using AutoMapper;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.NewStaffService.Service.Dtos
{
    public class NewStaffProfile : Profile
    {
        public NewStaffProfile()
        {
            CreateMap<NewStaffDto, NewStaff>().ReverseMap();
        }
    }
}
