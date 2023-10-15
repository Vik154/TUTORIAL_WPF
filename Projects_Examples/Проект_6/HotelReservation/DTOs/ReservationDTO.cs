using System.ComponentModel.DataAnnotations;

namespace HotelReservation.DTOs;

/// <summary> Класс - прослойка между логикой и базой данных </summary>
public class ReservationDTO {
    [Key]
    public Guid Id { get; set; }
    public int FloorNumber { get; set; }
    public int RoomNumber { get; set; }
    public string Username { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
