using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Exceptions
{
    public class UpdateNotAllowedException : Exception
    {
        public UpdateNotAllowedException()
        {
        }

        public UpdateNotAllowedException(string? message) : base(message)
        {
        }
    }
}
