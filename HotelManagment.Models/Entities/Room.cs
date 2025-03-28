using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelManagment.Models.Entities
{
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Boolean Free { get; set; }
        [Required]
        public int Price { get; set; }

        //1XM
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        
        public Hotel Hotel { get; set; }

        //1X1
        public int? GuestId { get; set; }
        public Guest Guest { get; set; }

        //1XM
        public List<Booking> Bookings { get; set; }

    }
}
