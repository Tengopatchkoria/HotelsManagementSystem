using HotelManagment.Models.Dtos.Booking;
using HotelManagment.Models.Dtos.Guest;
using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Models.Dtos.Manager;
using HotelManagment.Models.Dtos.Rooms;
using HotelManagment.Models.Entities;
using HotelManagment.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;


namespace HotelManagment.API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IManagerService _managerService;
        private readonly IGuestService _guestService;
        private readonly IBookingService _bookingService;

        public HotelsController(IHotelService hotelService, IRoomService roomService, IManagerService managerService, IGuestService guestService, IBookingService bookingService)
        {
            _hotelService = hotelService;
            _roomService = roomService;
            _managerService = managerService;
            _guestService = guestService;
            _bookingService = bookingService;
        }


        [HttpGet("hotel/{id}")]
        public async Task<IActionResult> GetHotel([FromRoute] int id)
        {
            var result = await _hotelService.GetHotelById(id);
            ApiResponse response = new(ApiResponseMessage.successMessage, result, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await _hotelService.GetAllHotels();
            ApiResponse response = new(ApiResponseMessage.successMessage, result, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPost("hotel/add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddHotel([FromForm] HotelsForCreatingDto model)
        {
            await _hotelService.AddHotel(model);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpDelete("hotel/delete/{hotelId}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteHotel([FromRoute] int hotelId)
        {
            await _hotelService.DeleteHotel(hotelId);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, hotelId, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPut("hotel/update")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateHotel([FromForm] HotelsForUpdatingDto model)
        {
            await _hotelService.UpdateHotel(model);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("room/add")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddRoom([FromForm] RoomsForCreatingDto model, [FromQuery] int hotelId)
        {
            await _roomService.AddRoomToHotel(model, hotelId);
            await _roomService.SaveRoom();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("room/delete/{roomId}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteRoom([FromRoute] int roomId)
        {
            await _roomService.RemoveRoom(roomId);
            await _roomService.SaveRoom();
            ApiResponse response = new(ApiResponseMessage.successMessage, roomId, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("room/update")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateRoom([FromForm] RoomsForUpdatingDto model)
        {
            await _roomService.UpdateRoom(model);
            await _roomService.SaveRoom();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("room/filter")]
        [Authorize]
        public async Task<IActionResult> GetFilteredRooms([FromQuery] int? hotelId, [FromQuery] bool? isAvailable, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var rooms = await _roomService.FilterRooms(hotelId, isAvailable, minPrice, maxPrice);
            ApiResponse response = new(ApiResponseMessage.successMessage, rooms, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("manager/add")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> AddManager([FromForm] ManagerForCreatingDto model)
        {
            await _managerService.AddManager(model);
            await _managerService.SaveManager();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("manager/delete/{managerId}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> RemoveManager([FromRoute] int managerId)
        {
            await _managerService.RemoveManager(managerId);
            await _managerService.SaveManager();
            ApiResponse response = new(ApiResponseMessage.successMessage, managerId, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("manager/update")]
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> UpdateManager([FromForm] ManagerForUpdatingDto model)
        {
            await _managerService.UpdateManager(model);
            await _managerService.SaveManager();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("guest/add")]
        public async Task<IActionResult> AddGuest([FromForm] GuestForCreatingDto model)
        {
            await _guestService.AddGuest(model);
            await _guestService.SaveGuest();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("guest/delete/{guestId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveGuest([FromRoute] int guestId)
        {
            await _guestService.RemoveGuest(guestId);
            await _guestService.SaveGuest();
            ApiResponse response = new(ApiResponseMessage.successMessage, guestId, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("guest/update")]
        public async Task<IActionResult> UpdateGuest([FromForm] GuestForUpdatingDto model)
        {
            await _guestService.UpdateGuest(model);
            await _guestService.SaveGuest();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("booking/add")]
        [Authorize (Roles = "Guest")]
        public async Task<IActionResult> Addbooking([FromForm] BookingForCreatingDto model)
        {
            await _bookingService.AddBooking(model);
            await _bookingService.SaveBooking();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("booking/delete/{bookingId}")]
        [Authorize(Roles = "Manager, Guest")]
        public async Task<IActionResult> RemoveBooking([FromRoute] int bookingId)
        {
            await _bookingService.RemoveBooking(bookingId);
            await _bookingService.SaveBooking();
            ApiResponse response = new(ApiResponseMessage.successMessage, bookingId, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("booking/update")]
        [Authorize(Roles = "Guest")]
        public async Task<IActionResult> UpdateBooking([FromForm] BookingForUpdatingDto model)
        {
            await _bookingService.UpdateBooking(model);
            await _bookingService.SaveBooking();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("booking/filter")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetFilteredBookings([FromQuery] int? hotelId, [FromQuery] int? guestId, [FromQuery] int? roomId, [FromQuery] DateTime? entryDate, [FromQuery] DateTime? leaveDate)
        {
            var rooms = await _bookingService.FilterBooking(hotelId, guestId, roomId, entryDate, leaveDate);
            ApiResponse response = new(ApiResponseMessage.successMessage, rooms, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
    }
}
