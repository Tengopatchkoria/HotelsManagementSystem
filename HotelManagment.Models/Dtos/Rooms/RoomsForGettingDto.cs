using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Rooms
{
    public class RoomsForGettingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean Free { get; set; }
        public string Price { get; set; }

    }
}
