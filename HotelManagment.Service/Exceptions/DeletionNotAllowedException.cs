using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Exceptions
{
    public class DeletionNotAllowedException : Exception
    {
        public DeletionNotAllowedException()
        {
        }

        public DeletionNotAllowedException(string? message) : base(message)
        {
        }
    }
}
