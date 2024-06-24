using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.Entites;
using Services.Hepler;
using Services.UserService;
using Services.UserService.Dto;
using WebApi.HandelResponses;
using WebApi.Helper;
using Service.UserService.Dto;

namespace WebApi.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IUserService _UserService;
        private readonly UserManager<Users> _UserManager;
        private readonly IEmailService emailService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService,
                                 UserManager<Users> userManager,
                                 IEmailService emailService,
                                 IConfiguration configuration)
        {
            _UserService = userService;
            _UserManager = userManager;
            this.emailService = emailService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            try
            {
                var user = await _UserService.Register(registerDto);
                


                return Ok(user);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _UserService.Login(loginDto);
            if (user == null)
                return Unauthorized(new ApiResponse(401));

            return Ok(user);

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            //var email = HttpContext.User?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.Email).Value;
            var email = User?.FindFirstValue(ClaimTypes.Email);

            if (email == null)
                return Unauthorized(new ApiResponse(401));

            var currentUser = await _UserService.GetCurrentUser(email);

            return Ok(currentUser);


        }





        [HttpPost]
        public async Task<ActionResult> ForgetPassword(ForgetPasswordDto email)
        {
            var user = await _UserManager.FindByEmailAsync(email.Email);
            if (user == null)
                return NotFound(new ApiResponse(404, "Wrong Email Address"));

            var token = await _UserManager.GenerateUserTokenAsync(user, "Default", "ResetPassword");

            // Construct the reset link manually
            var link = $"{_configuration["ResetUrlLink"]}{token}&email={email.Email}";

            var emailAddress = new Email()
            {
                To = email.Email,
                Subject = "Reset Password",
                Body = $"This is the link to reset your password: {link}"
            };

            var result = emailService.SendEmail(emailAddress);
            if (!result)
                return BadRequest(new ApiResponse(500, "Email Not Sent"));

            return Ok(new ApiResponse(200, "Email Sent successfully"));
        }

        [HttpGet]
        public async Task<ActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPasswordDto() { Token = token, Email = email };
            return Ok(model);

        }
        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPassword)
        {

            var user = await _UserManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
                return NotFound(new ApiResponse(404, "Email not Found"));

            var result = await _UserManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok(new ApiResponse(200, "Password has Changed Successfully"));

        }
        [HttpGet]
        public async Task<ActionResult<UserDto>> RefreshToken()
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);

            if (email == null)
                return Unauthorized(new ApiResponse(401));

            var user = await _UserService.GetRefreshToken(email);

            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo()
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);

            if (email == null)
                return Unauthorized(new ApiResponse(401));
            var user = await _UserService.GetUserInfo(email);

            return user;
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserInfo(UserInfoResultDto userInfo)
        {
            var email = User?.FindFirstValue(ClaimTypes.Email);

            if (email == null)
                return Unauthorized(new ApiResponse(401));

            await _UserService.UpdateUserInfo(userInfo, email);
            return RedirectToAction(nameof(GetUserInfo));
        }

    }
}
