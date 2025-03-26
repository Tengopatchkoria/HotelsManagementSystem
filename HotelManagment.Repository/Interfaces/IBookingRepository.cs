using HotelManagment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Repository.Interfaces
{
    public interface IBookingRepository : IRepositoryBase<Booking>, IUpdatable<Booking>
    {
        Task<List<Booking>> GetOverlappingBookingsAsync(int? roomId, DateTime EntryDate, DateTime LeaveDate, int? excludeBookingId = null);
    }
}
