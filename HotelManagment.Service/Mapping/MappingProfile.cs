using AutoMapper;
using HotelManagment.Models.Dtos.Guest;
using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Models.Dtos.Idenitity;
using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
            CreateMap<RoomsForCreatingDto, Room>();
            CreateMap<ManagerForCreatingDto, Manager>();
            CreateMap<GuestForCreatingDto, Guest>();

            CreateMap<HotelsForUpdatingDto, Hotel>();
            CreateMap<RoomsForUpdatingDto, Room>();
            CreateMap<ManagerForUpdatingDto, Manager>();
            CreateMap<GuestForUpdatingDto, Guest>();

            CreateMap<UserDto, ApplicationUser>().ReverseMap();
            CreateMap<RegistrationRequestDto, ApplicationUser>()
               .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.IdentityNumber))
               .ForMember(dest => dest.NormalizedUserName, options => options.MapFrom(src => src.IdentityNumber));
        }
    }
}
