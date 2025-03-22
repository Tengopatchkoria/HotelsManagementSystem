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
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        private readonly ApplicationDbContext _context;
        public ManagerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Manager entity)
        {
            var entityFromDb = await _context.Managers.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb is not null)
            {
                entityFromDb.FirstName = entity.FirstName;
                entityFromDb.LastName = entity.LastName;
                entityFromDb.IdentityNumber = entity.IdentityNumber;
                entityFromDb.Email = entity.Email;
                entityFromDb.PersonalNumber = entity.PersonalNumber;
            }
        }
    }
}
