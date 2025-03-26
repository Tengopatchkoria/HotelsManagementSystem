using HotelManagment.Models.Dtos.Idenitity;
using HotelManagment.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegistrationRequestDto model)
        {
            await _authService.Register(model);
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("registerAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] RegistrationRequestDto model)
        {
            await _authService.RegisterAdmin(model);
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("registerManager")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RegisterManager([FromForm] RegistrationRequestDto model)
        {
            await _authService.RegisterManager(model);
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto model)
        {
            var result = await _authService.Login(model);
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
    }
}
