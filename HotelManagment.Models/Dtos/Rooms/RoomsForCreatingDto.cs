using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Rooms
{
    public class RoomsForCreatingDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Boolean Free { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
