using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Rooms
{
    public class RoomsForGettingDto
    {
        public string Name { get; set; }
        public Boolean Free { get; set; }
        public int Price { get; set; }
    }
}
