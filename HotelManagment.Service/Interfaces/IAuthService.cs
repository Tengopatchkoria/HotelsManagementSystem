using HotelManagment.Models.Dtos.Idenitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Interfaces
{
    public interface IAuthService
    {
        Task RegisterGuest(GuestRegistrationRequestDto guestRegistrationRequestDto);
        Task RegisterManager(RegistrationRequestDto registrationRequestDto);
        Task RegisterAdmin(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
