using Service.CampService.Service.Dtos;

namespace Service.CampService.Interface
{
    public interface ICampService
    {
        Task<IReadOnlyList<CampDto>> GetAllCamps();

        Task<CampDto>  GetCampById(int id);
    }
}
