using Service.LocationService.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.LocationService.Interface
{
    public interface IlocationService
    {
        Task<IReadOnlyList<LocationDto>> GetAllLocationsAsync();

        Task<LocationDto> GetLocationById(int  id);
    }
}
