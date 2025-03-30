using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Hotels
{
    public class HotelsForGettingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ManagerId { get; set; }
        public ManagerForGettingDto Manager{ get; set; }
        public List<RoomsForGettingDto> Rooms { get; set; }

    }
}
