using HotelManagment.Models.Dtos.Idenitity;
using HotelManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Implementations
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAdmin(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterManager(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
