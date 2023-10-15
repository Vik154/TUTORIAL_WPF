using HotelReservation.DbContexts;
using HotelReservation.DTOs;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services.ReservationConflictValidators;

/// <summary> Класс проверки конфликтующих записей в книге бронирования </summary>
public class DatabaseReservationConflictValidator : IReservationConflictValidator {
    
    private readonly ReservoomDbContextFactory _dbContextFactory;

    public DatabaseReservationConflictValidator(ReservoomDbContextFactory dbContextFactory) {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Reservation> GetConflictingReservation(Reservation reservation) {
        
        using (ReservoomDbContext context = _dbContextFactory.CreateDbContext()) {
            ReservationDTO? reservationDTO = await context.Reservations
                .Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
                .Where(r => r.RoomNumber == reservation.RoomID.RoomNumber)
                .Where(r => r.EndTime > reservation.StartTime)
                .Where(r => r.StartTime < reservation.EndTime)
                .FirstOrDefaultAsync();

            if (reservationDTO == null) {
                return null;
            }

            return ToReservation(reservationDTO);
        }
    }

    private static Reservation ToReservation(ReservationDTO dto) {
        return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.Username, dto.StartTime, dto.EndTime);
    }
}
