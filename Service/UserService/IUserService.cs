
using Service.UserService.Dto;
using Services.UserService.Dto;

namespace Services.UserService
{
    public interface IUserService
    {

        public Task<UserDto> Register(RegisterDto registerDto);
        public Task<UserDto> Login(LoginDto loginDto);

        public Task<UserDto> GetCurrentUser(string email);

        public Task<UserDto> GetRefreshToken(string email);

        public Task<UserInfoDto> GetUserInfo(string email);
        public Task UpdateUserInfo(UserInfoResultDto userInfoDto, string email);







    }
}
