using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Interfaces
{
    public interface IRoomService
    {
        Task AddRoomToHotel(RoomsForCreatingDto roomsForCreatingDto);
        Task UpdateRoom(RoomsForUpdatingDto roomsForUpdatingDto);
        Task RemoveRoom(int roomId);
        Task<List<Room>> FilterRooms(int? hotelId, bool? isAvailable, decimal? minPrice, decimal? maxPrice);
        Task SaveRoom();
    }
}
