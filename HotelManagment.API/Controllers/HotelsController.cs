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
    [Authorize]
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
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await _hotelService.GetAllHotels();
            ApiResponse response = new(ApiResponseMessage.successMessage, result, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> AddHotel([FromBody] HotelsForCreatingDto model)
        {
            await _hotelService.AddHotel(model);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpDelete("hotel/{hotelId}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int hotelId)
        {
            await _hotelService.DeleteHotel(hotelId);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, hotelId, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelsForUpdatingDto model)
        {
            await _hotelService.UpdateHotel(model);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPost("hotel/assign-manager")]
        public async Task<IActionResult> AssignManager([FromBody] AssignManagerDto model)
        {
            await _hotelService.AssignManagerToHotel(model);
            await _hotelService.SaveHotel();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }




        [HttpPost("room/add")]
        public async Task<IActionResult> AddRoom([FromBody] RoomsForCreatingDto model)
        {
            await _roomService.AddRoomToHotel(model);
            await _roomService.SaveRoom();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("room/{roomId}")]
        public async Task<IActionResult> DeleteRoom([FromRoute] int roomId)
        {
            await _roomService.RemoveRoom(roomId);
            await _roomService.SaveRoom();
            ApiResponse response = new(ApiResponseMessage.successMessage, roomId, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("room/update")]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomsForUpdatingDto model)
        {
            await _roomService.UpdateRoom(model);
            await _roomService.SaveRoom();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("room/filter")]
        public async Task<IActionResult> GetFilteredRooms([FromQuery] int? hotelId, [FromQuery] bool? isAvailable, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            var rooms = await _roomService.FilterRooms(hotelId, isAvailable, minPrice, maxPrice);
            ApiResponse response = new(ApiResponseMessage.successMessage, rooms, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("manager/add")]
        public async Task<IActionResult> AddManager([FromBody] ManagerForCreatingDto model)
        {
            await _managerService.AddManager(model);
            await _managerService.SaveManager();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("manager/{managerId}")]
        public async Task<IActionResult> RemoveManager([FromRoute] int managerId)
        {
            await _managerService.RemoveManager(managerId);
            await _managerService.SaveManager();
            ApiResponse response = new(ApiResponseMessage.successMessage, managerId, 204, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("manager/update")]
        public async Task<IActionResult> UpdateManager([FromBody] ManagerForUpdatingDto model)
        {
            await _managerService.UpdateManager(model);
            await _managerService.SaveManager();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("guest/add")]
        public async Task<IActionResult> AddGuest([FromBody] GuestForCreatingDto model)
        {
            await _guestService.AddGuest(model);
            await _guestService.SaveGuest();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("guest/{guestId}")]
        public async Task<IActionResult> RemoveGuest([FromRoute] int guestId)
        {
            await _guestService.RemoveGuest(guestId);
            await _guestService.SaveGuest();
            ApiResponse response = new(ApiResponseMessage.successMessage, guestId, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("guest/update")]
        public async Task<IActionResult> UpdateGuest([FromBody] GuestForUpdatingDto model)
        {
            await _guestService.UpdateGuest(model);
            await _guestService.SaveGuest();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("booking/add")]
        public async Task<IActionResult> Addbooking([FromBody] BookingForCreatingDto model)
        {
            await _bookingService.AddBooking(model);
            await _bookingService.SaveBooking();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete("booking/{bookingId}")]
        public async Task<IActionResult> RemoveBooking([FromRoute] int bookingId)
        {
            await _bookingService.RemoveBooking(bookingId);
            await _bookingService.SaveBooking();
            ApiResponse response = new(ApiResponseMessage.successMessage, bookingId, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut("booking/update")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingForUpdatingDto model)
        {
            await _bookingService.UpdateBooking(model);
            await _bookingService.SaveBooking();
            ApiResponse response = new(ApiResponseMessage.successMessage, model, 201, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("booking/filter")]
        public async Task<IActionResult> GetFilteredBookings([FromQuery] int? hotelId, [FromQuery] int? guestId, [FromQuery] int? roomId, [FromQuery] DateTime? entryDate, [FromQuery] DateTime? leaveDate)
        {
            var rooms = await _bookingService.FilterBooking(hotelId, guestId, roomId, entryDate, leaveDate);
            ApiResponse response = new(ApiResponseMessage.successMessage, rooms, 200, isSuccess: true);
            return StatusCode(response.StatusCode, response);
        }
    }
}
