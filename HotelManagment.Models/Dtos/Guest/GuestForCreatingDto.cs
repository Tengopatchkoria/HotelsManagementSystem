using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Guest
{
    public class GuestForCreatingDto
    {
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
    }
}
