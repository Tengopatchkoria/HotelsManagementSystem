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
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Hotel entity)
        {
            var entityFromDb = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.Name = entity.Name;
                entityFromDb.Rating = entity.Rating;
                entityFromDb.Country = entity.Country;
                entityFromDb.City = entity.City;
                entityFromDb.Address = entity.Address;
            }
        }
    }
}
