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
        Task AddRoomToHotel(Room room, int hotelId);
        Task RoomAvailability(int roomId);
        Task PriceValidation(int roomId);
        Task UpdateRoom(Room room);
        Task RemoveRoom(int roomId);
        Task<List<Room>> FilterRooms();
        Task SaveRoom();
    }
}
