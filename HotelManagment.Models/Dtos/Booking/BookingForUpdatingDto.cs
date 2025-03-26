using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Booking
{
    public class BookingForUpdatingDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LeaveDate { get; set; }
    }
}
