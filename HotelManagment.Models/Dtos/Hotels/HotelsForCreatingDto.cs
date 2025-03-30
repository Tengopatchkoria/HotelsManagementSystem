using HotelManagment.Models.Dtos.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Hotels
{
    public class HotelsForCreatingDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        [Required]
        public int Rating { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public int ManagerId { get; set; }
    }
}
