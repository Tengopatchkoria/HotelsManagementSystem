using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Models.Dtos.Idenitity
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }
        public string password { get; set; }

    }
}
