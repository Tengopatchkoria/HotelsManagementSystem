using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagment.Models.Entities
{
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11)]
        public string IdentityNumber { get; set; }

        [Required]
        [StringLength(9)]
        [Column(TypeName = "char(9)")]
        public string PhoneNumber { get; set; }

        //1X1
        public Room Room { get; set; }

        //1X1
        public Booking? booking { get; set; }
    }
}
