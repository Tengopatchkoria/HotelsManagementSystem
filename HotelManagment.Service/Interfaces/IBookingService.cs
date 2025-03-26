using HotelManagment.Models.Dtos.Booking;
using HotelManagment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Interfaces
{
    public interface IBookingService
    {
        Task AddBooking(BookingForCreatingDto bookingForCreatingDto);
        Task UpdateBooking(BookingForUpdatingDto bookingForUpdatingDto);
        Task RemoveBooking(int bookingId);
        Task<List<Booking>> FilterBooking(int? hotelId, int? guestId, int? roomId, DateTime? entryDate, DateTime? leaveDate);
        Task SaveBooking();
    }
}
