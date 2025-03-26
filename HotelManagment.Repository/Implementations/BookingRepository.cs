using HotelManagment.Models.Entities;
using HotelManagment.Repository.Data;
using HotelManagment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Repository.Implementations
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Booking entity)
        {
            var entityFromDb = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.EntryDate = entity.EntryDate;
                entityFromDb.LeaveDate = entity.LeaveDate;
            } 
        }
        public async Task<List<Booking>> GetOverlappingBookingsAsync(int? roomId, DateTime EntryDate, DateTime LeaveDate, int? excludeBookingId = null)
        {
            var query = _context.Bookings
                .Where(b => b.RoomId == roomId &&
                            b.EntryDate < LeaveDate &&
                            b.LeaveDate > EntryDate);

            if (excludeBookingId.HasValue)
                query = query.Where(b => b.Id != excludeBookingId.Value);

            return await query.ToListAsync();
        }
    }
}
