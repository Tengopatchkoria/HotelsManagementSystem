using HotelManagment.Models.Dtos.Booking;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Service.Exceptions;
using HotelManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagment.Service.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;

        public BookingService( IBookingRepository bookingRepository, IRoomRepository roomRepository, IGuestRepository guestRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
        }

        public async Task AddBooking(BookingForCreatingDto bookingForCreatingDto)
        {
            var room = await _roomRepository.GetAsync(x => x.Id == bookingForCreatingDto.RoomId);
            if (room == null)
                throw new NotFoundException("Room not found");

            if (!room.Free)
                throw new ConflictException("Room is already booked");

            var guest = await _guestRepository.GetAsync(x => x.Id == bookingForCreatingDto.GuestId);
            if (guest == null)
                throw new NotFoundException("Guest not found");

            if (bookingForCreatingDto.EntryDate < DateTime.UtcNow.Date)
                throw new ValidationException("Check-in date must be today or in the future");

            if (bookingForCreatingDto.LeaveDate <= bookingForCreatingDto.EntryDate)
                throw new ValidationException("Check-out date must be after check-in date");

            var booking = new Booking
            {
                GuestId = bookingForCreatingDto.GuestId,
                RoomId = bookingForCreatingDto.RoomId,
                EntryDate = bookingForCreatingDto.EntryDate,
                LeaveDate = bookingForCreatingDto.LeaveDate,
            };

            room.Free = false;
            await _roomRepository.Update(room);

            await _bookingRepository.AddAsync(booking);
        }

        public async Task<List<Booking>> FilterBooking(int? hotelId, int? guestId, int? roomId, DateTime? entryDate, DateTime? leaveDate)
        {
            if (hotelId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.Room.HotelId == hotelId, includeProperties:"Guest, Room, HotelBookings");
            if (guestId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.GuestId == guestId, includeProperties: "Guest, Room, HotelBookings");
            if (roomId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.RoomId == roomId, includeProperties: "Guest, Room, HotelBookings");
            if (entryDate.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.EntryDate == entryDate, includeProperties: "Guest, Room, HotelBookings");
            if (leaveDate.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.LeaveDate == leaveDate, includeProperties: "Guest, Room, HotelBookings");

            return await _bookingRepository.GetAllAsync(includeProperties: "Guest, Room, HotelBookings");            
        }

        public async Task RemoveBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetAsync(x => x.Id == bookingId);
            if (booking == null)
                throw new NotFoundException("Booking not found");

            var room = await _roomRepository.GetAsync(x => x.Id == booking.RoomId);
            if (room == null)
                throw new NotFoundException("Room not found");

            _bookingRepository.Remove(booking);
            
            room.Free = true;
            await _roomRepository.Update(room);
        }

        public Task SaveBooking() => _bookingRepository.Save();

        public async Task UpdateBooking(BookingForUpdatingDto bookingForUpdatingDto)
        {
            var booking = await _bookingRepository.GetAsync(x => x.Id == bookingForUpdatingDto.Id);
            if (booking == null)
                throw new NotFoundException("Booking not found");

            var room = await _roomRepository.GetAsync(x => x.Id == booking.RoomId);
            if (room == null)
                throw new NotFoundException("Room not found");

            if (bookingForUpdatingDto.EntryDate< DateTime.UtcNow.Date)
                throw new ValidationException("Check-in date must be today or in the future");

            if (bookingForUpdatingDto.LeaveDate <= bookingForUpdatingDto.EntryDate)
                throw new ValidationException("Check-out date must be after check-in date");

            var overlappingBookings = await _bookingRepository.GetOverlappingBookingsAsync(
                booking.RoomId, bookingForUpdatingDto.EntryDate, bookingForUpdatingDto.LeaveDate, booking.Id);

            if (overlappingBookings.Any())
                throw new ConflictException("The new booking dates overlap with another booking");

            booking.EntryDate = bookingForUpdatingDto.EntryDate;
            booking.LeaveDate = bookingForUpdatingDto.LeaveDate;
            await _bookingRepository.Update(booking);
        }
    }
}
