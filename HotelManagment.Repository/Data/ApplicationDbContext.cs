using HotelManagment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.seedHotels();
            modelBuilder.seedManagers();
            modelBuilder.seedRooms();
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Manager> Managers{ get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}
