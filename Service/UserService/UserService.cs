using AutoMapper;
using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Service.UserService.Dto;
using Services.TokenService.Interface;
using Services.UserService.Dto;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<Users> _UserManager;
        private readonly ITokenService _TokenService;
        private readonly SignInManager<Users> _SignInManager;


        public UserService(UserManager<Users> userManager,
                           ITokenService tokenService,
                           SignInManager<Users> signInManager
                           )
        {
            _UserManager = userManager;
            _TokenService = tokenService;
            _SignInManager = signInManager;

        }

        

        public async Task<UserDto> GetCurrentUser(string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);

            return new UserDto
            {
                DisplayName = $"{user.FName} {user.Lname}",
                Email = user.Email,
                
            };
        }

        public async Task<UserDto> GetRefreshToken(string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            if (user == null)
                return null;

            return new UserDto
            {
                DisplayName = $"{user.FName} {user.Lname}",

                Email = user.Email,
                Token = _TokenService.CreateToken(user)
            };


        }

        public async Task<UserInfoDto> GetUserInfo(string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            if (user == null)
                return null;

            return new UserInfoDto
            {
                FName = user.FName,
                Lname = user.Lname,                
                Gender = user.Gender,
                Address = user.Address,
                DOB = user.DOB,

    

            };

        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _UserManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return null;
            var result = await _SignInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return null;

            return new UserDto
            {
                DisplayName = $"{user.FName} {user.Lname}",

                Email = user.Email,
                Token = _TokenService.CreateToken(user)
            };
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = await _UserManager.FindByEmailAsync(registerDto.Email);
            if (user != null)
                throw new HttpRequestException("This Email Already Exist",null, statusCode: System.Net.HttpStatusCode.BadRequest);

            var appUser = new Users
            {
                FName = registerDto.FName,
                Lname = registerDto.Lname,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split('@')[0],
                Address = registerDto.Address,
                DOB = registerDto.DOB,
                
                
            };
            var result = await _UserManager.CreateAsync(appUser, registerDto.Password);

            if (!result.Succeeded)
                throw new HttpRequestException( result.Errors.FirstOrDefault().Description, null, statusCode: System.Net.HttpStatusCode.BadRequest);
            

            return new UserDto
            {
                DisplayName = $"{appUser.FName} {appUser.Lname}",
                Email = appUser.Email,
                Token = _TokenService.CreateToken(appUser)
            };


        }

        public async Task UpdateUserInfo(UserInfoResultDto userInfoDto, string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            if (user == null) return;

            user.FName = userInfoDto.FName;
            user.Lname = userInfoDto.Lname;
            user.Gender = userInfoDto.Gender;
            user.Address = userInfoDto.Address;
            user.DOB = userInfoDto.DOB;
            await _UserManager.UpdateAsync(user);

            if(userInfoDto.Password != null && userInfoDto.ConfirmPassword != null) 
            { 
                await _UserManager.ChangePasswordAsync(user,userInfoDto.OldPassword,userInfoDto.Password);
            }
            

        }

       
    }
}
