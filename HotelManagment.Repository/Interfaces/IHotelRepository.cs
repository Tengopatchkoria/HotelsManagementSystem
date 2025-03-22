using HotelManagment.Models.Entities;
using HotelManagment.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Repository.Interfaces
{
    public interface IHotelRepository : IRepositoryBase<Hotel>, IUpdatable<Hotel>
    {
    }
}
