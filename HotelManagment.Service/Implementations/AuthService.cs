﻿using AutoMapper;
using HotelManagment.Models.Dtos.Guest;
using HotelManagment.Models.Dtos.Idenitity;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Data;
using HotelManagment.Repository.Implementations;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Service.Exceptions;
using HotelManagment.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGuestRepository _guestRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        private const string _adminRole = "Admin";
        private const string _guestRole = "Guest";
        private const string _managerRole = "Manager";

        public AuthService
            (
                ApplicationDbContext context,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager,
                IJwtTokenGenerator jwtTokenGenerator,
                IMapper mapper,
                IGuestRepository guestRepository,
                IManagerRepository managerRepository
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
            _guestRepository = guestRepository;
            _managerRepository = managerRepository;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.ApplicationUsers
                            .FirstOrDefaultAsync(x => x.UserName.ToLower().Trim() == loginRequestDto.UserName.ToLower().Trim());

            if (user is not null)
            {
                var isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (!isValid)
                    throw new InvalidPasswordException("Password Is Invalid");

                var roles = await _userManager.GetRolesAsync(user);
                var token = _jwtTokenGenerator.GenerateToken(user, roles);

                LoginResponseDto result = new() { Token = token };
                return result;
            }
            else
            {
                throw new NotFoundException($"User {loginRequestDto.UserName} not found");
            }
        }

        public async Task RegisterGuest(GuestRegistrationRequestDto guestRegistrationRequestDto)
        {
            var user = _mapper.Map<ApplicationUser>(guestRegistrationRequestDto);
            var result = await _userManager.CreateAsync(user, guestRegistrationRequestDto.Password);

            var GuestEntity = new Guest()
            {
                IdentityNumber = guestRegistrationRequestDto.IdentityNumber,
                PhoneNumber = guestRegistrationRequestDto.PhoneNumber,
                FirstName = guestRegistrationRequestDto.FirstName,
                LastName = guestRegistrationRequestDto.LastName,
                GuestBookings = []
            };

            var CheckGuest = await _guestRepository.GetAsync
                (x => x.IdentityNumber.ToLower().Trim() == guestRegistrationRequestDto.IdentityNumber.ToLower().Trim() &&
                x.PhoneNumber.ToLower().Trim() == guestRegistrationRequestDto.PhoneNumber.ToLower().Trim());

            if (CheckGuest is not null)
                throw new AmbigousNameException("Guest Already Registered");

            if (result.Succeeded)
            {
                var userToReturn = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(x => x.IdentityNumber.ToLower().Trim() == guestRegistrationRequestDto.IdentityNumber.ToLower().Trim());

                if (userToReturn is not null)
                {
                    if (!await _roleManager.RoleExistsAsync(_guestRole))
                        await _roleManager.CreateAsync(new IdentityRole(_guestRole));

                    await _userManager.AddToRoleAsync(userToReturn, _guestRole);
                    await _guestRepository.AddAsync(GuestEntity);
                    await _guestRepository.Save();
                }
            }
            else
            {
                throw new InvalidOperationException(result.Errors.FirstOrDefault().Description);
            }
        }
        public async Task RegisterAdmin(RegistrationRequestDto registrationRequestDto)
        {
            var user = _mapper.Map<ApplicationUser>(registrationRequestDto);
            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

            if (result.Succeeded)
            {
                var userToReturn = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(x => x.IdentityNumber.ToLower().Trim() == registrationRequestDto.IdentityNumber.ToLower().Trim());

                if (userToReturn is not null)
                {
                    if (!await _roleManager.RoleExistsAsync(_adminRole))
                        await _roleManager.CreateAsync(new IdentityRole(_adminRole));

                    await _userManager.AddToRoleAsync(userToReturn, _adminRole);
                }
            }
            else
            {
                throw new InvalidOperationException(result.Errors.FirstOrDefault().Description);
            }
        }
        public async Task RegisterManager(ManagerRegistrationRequestDto managerRegistrationRequestDto)
        {
            var user = _mapper.Map<ApplicationUser>(managerRegistrationRequestDto);
            var result = await _userManager.CreateAsync(user, managerRegistrationRequestDto.Password);
            
            var ManagerEntity = new Manager()
            {
                IdentityNumber = managerRegistrationRequestDto.IdentityNumber,
                FirstName = managerRegistrationRequestDto.FirstName,
                LastName = managerRegistrationRequestDto.LastName,
                PhoneNumber = managerRegistrationRequestDto.PhoneNumber,
                Email = managerRegistrationRequestDto.Email
            };

            var CheckManager = await _managerRepository.GetAsync
                (x => x.IdentityNumber.ToLower().Trim() == managerRegistrationRequestDto.IdentityNumber.ToLower().Trim() &&
                x.Email.ToLower().Trim() == managerRegistrationRequestDto.Email.ToLower().Trim());

            if (CheckManager is not null)
                throw new AmbigousNameException("Manager Already Registered");

            if (result.Succeeded)
            {
                var userToReturn = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(x => x.IdentityNumber.ToLower().Trim() == managerRegistrationRequestDto.IdentityNumber.ToLower().Trim());

                if (userToReturn is not null)
                {
                    if (!await _roleManager.RoleExistsAsync(_managerRole))
                        await _roleManager.CreateAsync(new IdentityRole(_managerRole));

                    await _userManager.AddToRoleAsync(userToReturn, _managerRole);
                    await _managerRepository.AddAsync(ManagerEntity);
                    await _managerRepository.Save();
                }
            }
            else
            {
                throw new InvalidOperationException(result.Errors.FirstOrDefault().Description);
            }
        }
    }
}
