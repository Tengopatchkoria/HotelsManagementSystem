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
    public class GuestBookingRepository : RepositoryBase<GuestBooking>, IGuestBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestBookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(GuestBooking entity)
        {
            var entityFromDb = await _context.GuestBookings.FirstOrDefaultAsync(x => x.Id == entity.Id);
            
            if (entityFromDb is not null)
            {
                entityFromDb.BookingId = entity.BookingId;
                entityFromDb.Booking = entity.Booking;
                entityFromDb.GuestId = entity.GuestId;
                entityFromDb.Guest = entity.Guest;
            }
        }
    }
}
