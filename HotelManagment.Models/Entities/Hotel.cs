using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelManagment.Models.Entities
{
    public class Hotel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }

        //1X1
        [ForeignKey(nameof(Manager))]
        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }

        //1XM
        [JsonIgnore]
        public List<Room> Rooms { get; set; }

    }
}
