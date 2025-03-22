using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Exceptions
{
    public class AmbigousNameException : Exception
    {
        public AmbigousNameException()
        {
        }

        public AmbigousNameException(string? message) : base(message)
        {
        }
    }
}
