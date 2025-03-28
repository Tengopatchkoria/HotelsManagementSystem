using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Interfaces
{
    public interface IHotelService
    {
        Task<List<HotelsForGettingDto>> GetAllHotels();
        Task<HotelsForGettingDto> GetHotelById(int hotelId);
        Task AddHotel(HotelsForCreatingDto hotel);
        Task UpdateHotel(HotelsForUpdatingDto hotel);
        Task DeleteHotel(int HotelId);
        Task SaveHotel();
    }
}
