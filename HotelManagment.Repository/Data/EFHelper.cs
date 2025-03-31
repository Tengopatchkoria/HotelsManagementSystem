using HotelManagment.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Repository.Data
{
    public static class EFHelper
    {
        public static void ChangeDefaultTableNames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity => entity.ToTable(name: "Users"));
            modelBuilder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRoles"));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable(name: "UserClaims"));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogins"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "RoleClaims"));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserTokens"));
        }
        public static void seedHotels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel 
            {   
                Id = 1,
                Name = "Grand Palace Hotel", 
                Rating = 5, 
                Country = "Georgia", 
                City = "Tbilisi", 
                Address = "Rustaveli Avenue 12",
                ManagerId = 1
            },
            new Hotel 
            { 
                Id = 2, 
                Name = "Luxury Resort", 
                Rating = 4, 
                Country = "Georgia", 
                City = "Batumi", 
                Address = "Black Sea Blvd 5",
                ManagerId = 2
            });
        }
        public static void seedManagers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(
            new Manager 
            { 
                Id = 1, 
                FirstName = "Giorgi", 
                LastName = "Beridze", 
                IdentityNumber = "12345678901", 
                Email = "giorgi@example.com", 
                PhoneNumber = "+995555123456", 
                HotelId = 1 },
            new Manager 
            { 
                Id = 2, 
                FirstName = "Nino", 
                LastName = "Kopaleishvili", 
                IdentityNumber = "98765432109", 
                Email = "nino@example.com", 
                PhoneNumber = "+995599987654", 
                HotelId = 2
            });
        }
        public static void seedRooms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Deluxe Suite", Free = true, Price = 150, HotelId = 1 },
            new Room { Id = 2, Name = "Standard Room", Free = false, Price = 90, HotelId = 1 },
            new Room { Id = 3, Name = "Ocean View Room", Free = true, Price = 200, HotelId = 2 }
        );
        }
        public static void seedGuests(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
           new Guest { Id = 1, FirstName = "John", LastName = "Doe", IdentityNumber = "12345678901", PhoneNumber = "+995599111111" },
           new Guest { Id = 2, FirstName = "Alice", LastName = "Smith", IdentityNumber = "98765432109", PhoneNumber = "+995599222222" }
           );
        }
        public static void seedBookings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
            new Booking
            {
                Id = 1,
                RoomId = 1,
                EntryDate = DateTime.UtcNow.AddDays(2),
                LeaveDate = DateTime.UtcNow.AddDays(5),
            },
            new Booking
            {
                Id = 2,
                RoomId = 2,
                EntryDate = DateTime.UtcNow.AddDays(3),
                LeaveDate = DateTime.UtcNow.AddDays(7),
            }
            );
        }
        public static void seedGuestBookings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestBooking>().HasData(
                new GuestBooking { Id = 1, GuestId = 1, BookingId = 1 },
                new GuestBooking { Id = 2, GuestId = 2, BookingId = 2 }
            );
        }
        public static void seedRoles(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "3", Name = "Guest", NormalizedName = "GUEST" }
            );
        }
        public static void seedUsers(this ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser
            {
                Id = "101",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                FirstName = "admin",
                LastName = "admingero",
                IdentityNumber = "00201071653"
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Admin@123");

            var manager = new ApplicationUser
            {
                Id = "102",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                FirstName = "manager",
                LastName = "mangero",
                IdentityNumber = "00201071653"
            };
            manager.PasswordHash = hasher.HashPassword(manager, "Manager@123");

            var guest = new ApplicationUser
            {
                Id = "103",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                FirstName = "guest",
                LastName = "guestgero",
                IdentityNumber = "10201171653"
            };
            guest.PasswordHash = hasher.HashPassword(guest, "Guest@123");

            builder.Entity<ApplicationUser>().HasData(admin, manager, guest);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "101", RoleId = "1" }, // Admin
                new IdentityUserRole<string> { UserId = "102", RoleId = "2" }, // Manager
                new IdentityUserRole<string> { UserId = "103", RoleId = "3" }  // Guest
            );
        }
    }
}
