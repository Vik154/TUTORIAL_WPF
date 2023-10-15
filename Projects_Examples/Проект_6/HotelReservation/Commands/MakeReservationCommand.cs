using HotelReservation.Models;
using HotelReservation.ViewModels;

namespace HotelReservation.Commands;

/// <summary> Команда бронирования номеров </summary>
public class MakeReservationCommand : BaseCommand {

    private readonly MakeReservationViewModel _makeReservationViewModel;
    private readonly Hotel _hotel;
    public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel) {
        _makeReservationViewModel = makeReservationViewModel;
        _hotel = hotel;
    }

    public override void Execute(object? parameter) {
        Reservation reservation = new Reservation(
            new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
            _makeReservationViewModel.UserName,
            _makeReservationViewModel.StartDate,
            _makeReservationViewModel.EndDate
        );

        _hotel.MakeReservation(reservation);
    }
}
