using AutoMapper;
using HotelManagment.Models.Dtos.Guest;
using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Implementations;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Service.Exceptions;
using HotelManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Implementations
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        public GuestService(IMapper mapper, IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }
        public async Task AddGuest(GuestForCreatingDto guestForCreatingDto)
        {
            if (guestForCreatingDto is null)
                throw new BadRequestException("Invalid Argument");

            var CheckGuest = await _guestRepository.GetAsync
                (x => x.IdentityNumber.ToLower().Trim() == guestForCreatingDto.IdentityNumber.ToLower().Trim() &&
                x.PhoneNumber.ToLower().Trim() == guestForCreatingDto.PhoneNumber.ToLower().Trim());

            if (CheckGuest is not null)
                throw new AmbigousNameException("Guest Already Registered");

            var mappedGuest = _mapper.Map<Guest>(guestForCreatingDto);
            await _guestRepository.AddAsync(mappedGuest);
        }

        public async Task RemoveGuest(int guestId)
        {
            var GuestToDelete = await _guestRepository.GetAsync(x => x.Id == guestId);
            
            if(GuestToDelete is null)
            {
                throw new NotFoundException("Guest not found");
            }
            
            if(GuestToDelete.GuestBookings is not null)
                throw new DeletionNotAllowedException("Cannot Remove Guest.They Have Active Booking");

            _guestRepository.Remove(GuestToDelete);
        }

        public async Task UpdateGuest(GuestForUpdatingDto guestForUpdatingDto)
        {
            if (guestForUpdatingDto is null)
                throw new NotFoundException("Guest You Want To Update Does Not Exist");

            var entityData = _mapper.Map<Guest>(guestForUpdatingDto);
            await _guestRepository.Update(entityData);
        }
        public Task SaveGuest() => _guestRepository.Save();
    }
}
