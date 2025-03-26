using HotelManagment.Models.Dtos.Guest;
using HotelManagment.Models.Dtos.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Interfaces
{
    public interface IGuestService
    {
        Task AddGuest(GuestForCreatingDto guestForCreatingDto);
        Task UpdateGuest(GuestForUpdatingDto guestForUpdatingDto);
        Task RemoveGuest(int guestId);
        Task SaveGuest();
    }
}
