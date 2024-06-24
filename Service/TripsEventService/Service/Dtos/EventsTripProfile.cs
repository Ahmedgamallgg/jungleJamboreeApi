using AutoMapper;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TripsEventService.Service.Dtos
{
    public class EventsTripProfile :Profile
    {
        public EventsTripProfile()
        {
            CreateMap<TripsEvents,TripsEventDto>().ReverseMap();
        }
    }
}
