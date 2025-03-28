using HotelManagment.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ChangeDefaultTableNames();


            modelBuilder.seedHotels();
            modelBuilder.seedManagers();
            modelBuilder.seedRooms();
            modelBuilder.seedGuests();
            modelBuilder.seedBookings();
            modelBuilder.seedGuestBookings();
            modelBuilder.seedRoles();
            modelBuilder.seedUsers();
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Manager> Managers{ get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
