using HotelManagment.Models.Dtos.Idenitity;
using HotelManagment.Service.Implementations;
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
        private readonly IGuestService _guestService;

        public AuthController(IAuthService authService, IGuestService guestService)
        {
            _authService = authService;
            _guestService = guestService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] GuestRegistrationRequestDto model)
        {
            await _authService.RegisterGuest(model);
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
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> RegisterManager([FromForm] ManagerRegistrationRequestDto model)
        {
            await _authService.RegisterManager(model);
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto model)
        {
            var result = await _authService.Login(model);
            ApiResponse response = new(ApiResponseMessage.successMessage, result, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
    }
}
