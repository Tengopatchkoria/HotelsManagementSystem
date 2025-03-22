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
    public class GuestRepository : RepositoryBase<Guest>, IGuestRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestRepository(ApplicationDbContext context) : base(context)
        {
            context = _context;
        }

        public async Task Update(Guest entity)
        {
            var entityFromDb = await _context.Guests.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.FirstName = entity.FirstName;
                entityFromDb.LastName = entity.LastName;
                entityFromDb.IdentityNumber = entity.IdentityNumber;
                entityFromDb.PhoneNumber = entity.PhoneNumber;
            }
        }
    }
}
