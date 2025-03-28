using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Rooms
{
    public class RoomsForUpdatingDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Boolean Free { get; set; } = true;
        [Required]
        public int Price { get; set; }
    }
}
