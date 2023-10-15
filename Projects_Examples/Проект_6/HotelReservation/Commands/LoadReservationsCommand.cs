using HotelReservation.Models;
using HotelReservation.Stores;
using HotelReservation.ViewModels;
using System.Windows;

namespace HotelReservation.Commands;

/// <summary> Асинхронная команда загрузки данных </summary>
public class LoadReservationsCommand : AsyncCommandBase {

    private readonly ReservationListingViewModel _viewModel;
    private readonly HotelStore _hotelStore;

    public LoadReservationsCommand(ReservationListingViewModel viewModel, HotelStore hotelStore) {
        _viewModel = viewModel;
        _hotelStore = hotelStore;
    }

    public override async Task ExecuteAsync(object parameter) {

        _viewModel.IsLoading = true;

        try {
            await _hotelStore.Load();
            _viewModel.UpdateReservations(_hotelStore.Reservations);
        }
        catch (Exception) {
            MessageBox.Show("Ошибка загрузки записей резервирования", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
        }
        _viewModel.IsLoading = false;
    }

    //public override async Task ExecuteAsync(object parameter) {
    //    try {
    //        IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();
    //        _viewModel.UpdateReservations(reservations);
    //    }
    //    catch (Exception) {
    //        MessageBox.Show("Ошибка загрузки записей резервирования", "Error",
    //                        MessageBoxButton.OK, MessageBoxImage.Error);
    //    }
    //}
}
