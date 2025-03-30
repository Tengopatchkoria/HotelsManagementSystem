using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Exceptions
{
    public class ManagerTakenException : Exception
    {
        public ManagerTakenException()
        {
        }

        public ManagerTakenException(string? message) : base(message)
        {
        }
    }
}
