using Service.NewStaffService.Service.Dtos;

namespace Service.NewStaffService.Interface
{
    public interface INewStaffService
    {
        Task<bool> ApplyNewStaff(NewStaffDto staffDto, string email);

    }
}
