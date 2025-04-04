﻿using System.ComponentModel.DataAnnotations;
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
        [StringLength(50)]
        [Column(TypeName = "char(50)")]
        public string PhoneNumber { get; set; }

        //1XM
        public List<GuestBooking> GuestBookings { get; set; }
    }
}
