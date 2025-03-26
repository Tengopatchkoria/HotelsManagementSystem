using HotelManagment.Models.Dtos.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Interfaces
{
    public interface IManagerService
    {
        Task AddManager(ManagerForCreatingDto managerForCreatingDto);
        Task UpdateManager(ManagerForUpdatingDto managerForUpdatingDto);
        Task RemoveManager(int managerId);
        Task SaveManager();
    }
}
