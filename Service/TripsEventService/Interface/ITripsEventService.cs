using Service.TripsEventService.Service.Dtos;
using Services.Hepler;

namespace Service.TripsEventService.Interface
{
    public interface ITripsEventService
    {
        Task ApplyTripsEvent(TripsEventDto tripsEventDto,string email);

    }
}
