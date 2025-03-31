using AutoMapper;
using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Data;
using HotelManagment.Repository.Implementations;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Service.Exceptions;
using HotelManagment.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Implementations
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;
        private readonly ApplicationDbContext _context;

        public ManagerService(IMapper mapper, IManagerRepository managerRepository, IHotelRepository hotelRepository, ApplicationDbContext context)
        {
            _managerRepository = managerRepository;
            _context = context;
            _mapper = mapper;
            _hotelRepository = hotelRepository;
        }
        public async Task AddManager(ManagerForCreatingDto managerForCreatingDto)
        {
            if (managerForCreatingDto is null)
                throw new BadRequestException("Invalid Argument");

            var CheckManager = await _managerRepository.GetAsync
                (x => x.IdentityNumber.ToLower().Trim() == managerForCreatingDto.IdentityNumber.ToLower().Trim() &&
                x.Email.ToLower().Trim() == managerForCreatingDto.Email.ToLower().Trim());

            if (CheckManager is not null)
                throw new AmbigousNameException("Manager Already Registered");

            var mappedManager = _mapper.Map<Manager>(managerForCreatingDto);
            await _managerRepository.AddAsync(mappedManager);
        }

        public async Task RemoveManager(int managerId)
        {
            var managerToDelete = await _managerRepository.GetAsync(x => x.Id == managerId);
            var userToRemove = _context.Users.FirstOrDefault(x => x.UserName == managerToDelete.IdentityNumber);
            var UserRoleToRemove = _context.UserRoles.FirstOrDefault(x => x.UserId == userToRemove.Id);

            if (managerToDelete == null)
                throw new NotFoundException("Manager not found");

            var hotel = await _hotelRepository.GetAsync(x => x.Id == managerToDelete.HotelId);
            if (hotel != null)
            {
                throw new DeletionNotAllowedException("Cannot delete manager. The hotel must have at least one manager.");
            }
            _managerRepository.Remove(managerToDelete);
            _context.UserRoles.Remove(UserRoleToRemove);
            _context.Users.Remove(userToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManager(ManagerForUpdatingDto managerForUpdatingDto)
        {
            if(managerForUpdatingDto is null)
                throw new NotFoundException("Manager You Want To Update Is Not In The Database");

            var entityData = _mapper.Map<Manager>(managerForUpdatingDto);
            await _managerRepository.Update(entityData);
        }
        public async Task SaveManager() => await _managerRepository.Save();

    }
}
