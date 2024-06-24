using Service.BirthdayService.Service.Dtos;

namespace Service.BirthdayService.Interface
{
    public interface IBirthdayService
    {
        Task CreateBirthday(BirthdayDto birthdayDto, string email);
    }
}
