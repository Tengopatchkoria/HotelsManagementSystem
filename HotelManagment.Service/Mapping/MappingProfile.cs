using AutoMapper;
using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelsForGettingDto>();
            CreateMap<Room, RoomsForGettingDto>();
            CreateMap<Manager, ManagerForGettingDto>();

            CreateMap<HotelsForCreatingDto, Hotel>();

            CreateMap<HotelsForUpdatingDto, Hotel>();
        }
    }
}
