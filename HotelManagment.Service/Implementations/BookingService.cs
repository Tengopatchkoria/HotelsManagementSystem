using HotelManagment.Models.Dtos.Booking;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Implementations;
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
        private readonly IGuestBookingRepository _guestBookingRepository;

        public BookingService( IBookingRepository bookingRepository, IRoomRepository roomRepository, IGuestRepository guestRepository, IGuestBookingRepository guestBookingRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
            _guestBookingRepository = guestBookingRepository;
        }

        public async Task AddBooking(BookingForCreatingDto bookingForCreatingDto)
        {
            var room = await _roomRepository.GetAsync(x => x.Id == bookingForCreatingDto.RoomId);
            if (room == null)
                throw new NotFoundException("Room not found");

            if (!room.Free)
                throw new ConflictException("Room is already booked");

            if (bookingForCreatingDto.EntryDate < DateTime.UtcNow.Date)
                throw new ValidationException("Check-in date must be today or in the future");

            if (bookingForCreatingDto.LeaveDate <= bookingForCreatingDto.EntryDate)
                throw new ValidationException("Check-out date must be after check-in date");

            var booking = new Booking
            {
                RoomId = bookingForCreatingDto.RoomId,
                EntryDate = bookingForCreatingDto.EntryDate,
                LeaveDate = bookingForCreatingDto.LeaveDate,
            };

            foreach (var guestId in bookingForCreatingDto.GuestIds)
            {
                var guest = await _guestRepository.GetAsync(x => x.Id == guestId);
                if (guest == null)
                    throw new NotFoundException($"Guest with ID {guestId} not found");

                var guestBooking = new GuestBooking { GuestId = guestId, BookingId = booking.Id };
                await _guestBookingRepository.AddAsync(guestBooking);
            }

            room.Free = false;
            await _roomRepository.Update(room);

            await _bookingRepository.AddAsync(booking);
        }

        public async Task<List<Booking>> FilterBooking(int? hotelId, int? guestId, int? roomId, DateTime? entryDate, DateTime? leaveDate)
        {
            if (hotelId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.Room.HotelId == hotelId, includeProperties: "Room, GuestBookings");
            if (guestId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.GuestBookings.FirstOrDefault(x => x.GuestId == guestId).GuestId == guestId, includeProperties: "Room, GuestBookings");
            if (roomId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.RoomId == roomId, includeProperties: "Room, GuestBookings");
            if (entryDate.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.EntryDate == entryDate, includeProperties: "Room, GuestBookings");
            if (leaveDate.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.LeaveDate == leaveDate, includeProperties: "Room, GuestBookings");

            return await _bookingRepository.GetAllAsync(includeProperties: "Room, GuestBookings");            
        }

        public async Task RemoveBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetAsync(x => x.Id == bookingId);
            if (booking == null)
                throw new NotFoundException("Booking not found");

            var room = await _roomRepository.GetAsync(x => x.Id == booking.RoomId);
            if (room == null)
                throw new NotFoundException("Room not found");

            booking.GuestBookings.Clear();
            await _bookingRepository.Update(booking);

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
