using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Exceptions
{
    public class RoomIsBusyException : Exception
    {
        public RoomIsBusyException()
        {
        }

        public RoomIsBusyException(string? message) : base(message)
        {
        }
    }
}
