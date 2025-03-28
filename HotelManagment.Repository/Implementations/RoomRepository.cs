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
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Room entity)
        {
            var entityFromDb = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.Name = entity.Name;
                entityFromDb.Free = entity.Free;
                entityFromDb.Price = entity.Price;
            }
        }
    }
}
