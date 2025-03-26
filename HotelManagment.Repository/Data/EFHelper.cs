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
                Address = "Rustaveli Avenue 12" 
            },
            new Hotel 
            { 
                Id = 2, 
                Name = "Luxury Resort", 
                Rating = 4, 
                Country = "Georgia", 
                City = "Batumi", 
                Address = "Black Sea Blvd 5"
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

    }
}
