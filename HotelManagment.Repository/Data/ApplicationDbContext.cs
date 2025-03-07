using HotelManagment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagment.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
