using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelManagment.Models.Entities
{
    public class GuestBooking
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }


        [ForeignKey(nameof(Booking))]
        public int BookingId { get; set; }
        [JsonIgnore]
        public Booking Booking { get; set; }
    }
}
