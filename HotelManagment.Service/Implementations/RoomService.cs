using AutoMapper;
using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper, IHotelRepository hotelRepository)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task AddRoomToHotel(RoomsForCreatingDto roomsForCreatingDto, int hotelId)
        {
            if (roomsForCreatingDto is null)
                throw new BadRequestException("Invalid Argument");
            else if (roomsForCreatingDto.Price <= 0)
                throw new InvalidPriceException("Room Price Cannot Be Negative Or 0");
            else if(await _hotelRepository.GetAsync(x=> x.Id == hotelId) == null)
                throw new NotFoundException("Hotel Doesnt Exist");
            

            var CheckRoom = await _roomRepository.GetAsync
                (x => x.Name.ToLower().Trim() == roomsForCreatingDto.Name.ToLower().Trim());

            if (CheckRoom is not null)
                throw new AmbigousNameException("Name Or Address Is Unavaliable");

            var MappedRoom = _mapper.Map<Room>(roomsForCreatingDto);
            MappedRoom.HotelId = hotelId;
            MappedRoom.Hotel = await _hotelRepository.GetAsync(x => x.Id == hotelId);
            await _roomRepository.AddAsync(MappedRoom);
        }

        public async Task RemoveRoom(int roomId)
        {
            var RoomToDelete = await _roomRepository.GetAsync(x => x.Id == roomId);

            if (!RoomToDelete.Free || RoomToDelete.GuestId != null)
            {
                throw new RoomIsBusyException("Room Your Trying To Delete Is Taken");
            }
            _roomRepository.Remove(RoomToDelete);
        }

        public async Task SaveRoom() => await _roomRepository.Save();
        public async Task<List<Room>> FilterRooms(int? hotelId, bool? isAvailable, decimal? minPrice, decimal? maxPrice)
        {
            if (hotelId.HasValue)
                return await _roomRepository.GetAllAsync(r => r.HotelId == hotelId, includeProperties: "Hotel,Guest");
            if (isAvailable.HasValue)
                return await _roomRepository.GetAllAsync(r => r.Free == isAvailable.Value, includeProperties: "Hotel,Guest");

            if (minPrice.HasValue)
                return await _roomRepository.GetAllAsync(r => r.Price >= minPrice.Value, includeProperties: "Hotel,Guest");

            if (maxPrice.HasValue)
                return await _roomRepository.GetAllAsync(r => r.Price <= maxPrice.Value, includeProperties: "Hotel,Guest");

            return await _roomRepository.GetAllAsync(includeProperties: "Hotel,Guest");
        }
        public async Task UpdateRoom(RoomsForUpdatingDto roomsForUpdatingDto)
        {
            if(roomsForUpdatingDto is null)
                throw new NotFoundException("Not Found");
            var entityData = _mapper.Map<Room>(roomsForUpdatingDto);
            await _roomRepository.Update(entityData); 
        }
    }
}
