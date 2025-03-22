using HotelManagment.Models.Dtos.Hotels;
using HotelManagment.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HotelManagment.API.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel([FromRoute] int id)
        {
            var result = await _hotelService.GetHotelById(id);
            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await _hotelService.GetAllHotels();
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddHotel([FromBody] HotelsForCreatingDto model)
        {
            await _hotelService.AddHotel(model);
            await _hotelService.SaveHotel();
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int hotelId)
        {
            await _hotelService.DeleteHotel(hotelId);
            await _hotelService.SaveHotel();
            return NoContent();
        }
    }
}
