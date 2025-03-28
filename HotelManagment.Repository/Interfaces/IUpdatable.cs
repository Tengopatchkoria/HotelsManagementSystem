﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Repository.Interfaces
{
    public interface IUpdatable<T> where T : class
    {
        Task Update(T entity);
    }
}
