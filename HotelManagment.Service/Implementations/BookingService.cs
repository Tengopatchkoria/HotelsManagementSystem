using HotelManagment.Models.Dtos.Booking;
using HotelManagment.Models.Entities;
using HotelManagment.Repository.Implementations;
using HotelManagment.Repository.Interfaces;
using HotelManagment.Service.Exceptions;
using HotelManagment.Service.Interfaces;
using Microsoft.Identity.Client;
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

            var overlappingBookings = await _bookingRepository.GetOverlappingBookingsAsync(
                room.Id, bookingForCreatingDto.EntryDate, bookingForCreatingDto.LeaveDate);

            if (overlappingBookings.Any())
                throw new ConflictException("The booking dates overlap with another booking");

            if (bookingForCreatingDto.EntryDate < DateTime.UtcNow.Date)
                throw new ValidationException("Check-in date must be today or in the future");

            if (bookingForCreatingDto.LeaveDate <= bookingForCreatingDto.EntryDate)
                throw new ValidationException("Check-out date must be after check-in date");
            
            var guest = await _guestRepository.GetAsync(x => x.Id == bookingForCreatingDto.GuestId);
            if (guest == null)
                throw new NotFoundException($"Guest with ID {guest.Id} not found");

            var booking = new Booking
            {
                RoomId = bookingForCreatingDto.RoomId,
                Room = room,
                EntryDate = bookingForCreatingDto.EntryDate,
                LeaveDate = bookingForCreatingDto.LeaveDate,
            };
            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.Save();


            var guestBooking = new GuestBooking { GuestId = guest.Id, BookingId = booking.Id, Guest = guest, Booking = booking};
            await _guestBookingRepository.AddAsync(guestBooking);
            await _guestBookingRepository.Save();

            //booking.GuestBookings.Add(guestBooking);
            //await _bookingRepository.Update(booking);
            //await _bookingRepository.Save();

            //guest.GuestBookings.Add(guestBooking);
            //await _guestRepository.Update(guest);
            //await _guestRepository.Save();

            room.Free = false;
            //room.Bookings.Add(booking);
            await _roomRepository.Update(room);
            await _roomRepository.Save();

        }

        public async Task<List<Booking>> FilterBooking(int? hotelId, int? guestId, int? roomId, DateTime? entryDate, DateTime? leaveDate)
        {
            if (hotelId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.Room.HotelId == hotelId, includeProperties: "Room,GuestBookings");
            if (guestId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.GuestBookings.FirstOrDefault(x => x.GuestId == guestId).GuestId == guestId, includeProperties: "Room,GuestBookings");
            if (roomId.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.RoomId == roomId, includeProperties: "Room,GuestBookings");
            if (entryDate.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.EntryDate == entryDate, includeProperties: "Room,GuestBookings");
            if (leaveDate.HasValue)
                return await _bookingRepository.GetAllAsync(x => x.LeaveDate == leaveDate, includeProperties: "Room,GuestBookings");

            return await _bookingRepository.GetAllAsync(includeProperties: "Room,GuestBookings");            
        }

        public async Task RemoveBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetAsync(x => x.Id == bookingId);
            if (booking == null)
                throw new NotFoundException("Booking not found");

            var room = await _roomRepository.GetAsync(x => x.Id == booking.RoomId);
            if (room == null)
                throw new NotFoundException("Room not found");

            var guest = await _guestRepository.GetAsync(x => x.GuestBookings.FirstOrDefault(x => x.BookingId == bookingId).BookingId == bookingId );

            var guestBooking = await _guestBookingRepository.GetAsync(x => x.BookingId == bookingId);
            
            //guest.GuestBookings.Remove(guestBooking);
            //await _guestRepository.Update(guest);
            //await _guestRepository.Save();

            _guestBookingRepository.Remove(guestBooking);
            await _guestBookingRepository.Save();

            //booking.GuestBookings.Clear();
            //await _bookingRepository.Update(booking);
            _bookingRepository.Remove(booking);
            await _bookingRepository.Save();

            room.Free = true;
            //room.Bookings.Remove(booking);
            await _roomRepository.Update(room);
            await _roomRepository.Save();

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
