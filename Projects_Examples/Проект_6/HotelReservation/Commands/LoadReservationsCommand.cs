using HotelReservation.Models;
using HotelReservation.ViewModels;
using System.Windows;

namespace HotelReservation.Commands;

/// <summary> Асинхронная команда загрузки данных </summary>
public class LoadReservationsCommand : AsyncCommandBase {
    private readonly ReservationListingViewModel _viewModel;
    private readonly Hotel _hotel;

    public LoadReservationsCommand(ReservationListingViewModel viewModel, Hotel hotel) {
        _viewModel = viewModel;
        _hotel = hotel;
    }

    public override async Task ExecuteAsync(object parameter) {
        try {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();
            _viewModel.UpdateReservations(reservations);
        }
        catch (Exception) {
            MessageBox.Show("Ошибка загрузки записей резервирования", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
