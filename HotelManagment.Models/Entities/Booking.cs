using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Models.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EntryDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime LeaveDate { get; set; }

        //MXM
        public List<HotelBooking> HotelBookings { get; set; }
    }
}
