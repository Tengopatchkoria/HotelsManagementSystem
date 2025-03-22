using AutoMapper;
using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Repository.Migrations;
using HotelManagment.Service.Exceptions;
using HotelManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace HotelManagment.Service.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task AddHotel(HotelsForCreatingDto hotelForCreatingDto)
        {
            if (hotelForCreatingDto is null)
                throw new BadRequestException("Invalid Argument");

            var CheckHotel = await _hotelRepository.GetAsync(x => x.Name.ToLower().Trim() == hotelForCreatingDto.Name.ToLower().Trim());

            if (CheckHotel is not null)
                throw new AmbigousNameException();

            var MappedHotel = _mapper.Map<Hotel>(hotelForCreatingDto); 
            await _hotelRepository.AddAsync(MappedHotel);
        }

        public async Task DeleteHotel(int HotelId)
        {
            var hotelToDelete = await _hotelRepository.GetAsync(x => x.Id == HotelId);

            foreach( Room room in hotelToDelete.Rooms)
            {
                if (room.Free == false)
                    throw new DeletionNotAllowedException("One Of The Rooms Is Booked Or Active");
            }
            _hotelRepository.Remove(hotelToDelete);
        }

        public async Task<List<HotelsForGettingDto>> GetAllHotels()
        {
            var entityData = await _hotelRepository.GetAllAsync();
            List<HotelsForGettingDto> result = new();

            if (entityData.Any())
            {
                var mappedData = _mapper.Map<List<HotelsForGettingDto>>(entityData);
                result.AddRange(mappedData);
                return result;
            }
            else
            {
                throw new NotFoundException($"Hotels not found");
            }
        }

        public async Task<HotelsForGettingDto> GetHotelById(int hotelId)
        {
            HotelsForGettingDto result = new();

            if (hotelId < 1)
                throw new BadRequestException($"{hotelId} is an invalid argument");
            
            var entityData =  await _hotelRepository.GetAsync(x => x.Id == hotelId);

            if(entityData is null)
                throw new NotFoundException($"{hotelId} ");

            if (entityData.Rooms.Any())
            {
                result = _mapper.Map<HotelsForGettingDto>(entityData);
            }

            return result;
        }
        public async Task UpdateHotel(HotelsForUpdatingDto hotel)
        {
            if (hotel is null)
                throw new NotFoundException("Hotel You Want To Update Is Not In The Database");

            var entityData = _mapper.Map<Hotel>(hotel);
            await _hotelRepository.Update(entityData);
        }
        public async Task SaveHotel()
        {
            await _hotelRepository.Save();
        }
    }
}
