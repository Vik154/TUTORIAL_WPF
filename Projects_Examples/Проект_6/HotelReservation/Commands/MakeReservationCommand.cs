using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using HotelReservation.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace HotelReservation.Commands;

/// <summary> Команда бронирования номеров </summary>
public class MakeReservationCommand : AsyncCommandBase {

    private readonly MakeReservationViewModel _makeReservationViewModel;
    private readonly HotelStore _hotelStore;
    private readonly NavigationService<ReservationListingViewModel> _reservationViewNavigationService;

    public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, 
                                  HotelStore hotelStore,
                                  NavigationService<ReservationListingViewModel> reservationViewNavigationService) 
    {
        _makeReservationViewModel = makeReservationViewModel;
        _hotelStore = hotelStore;
        _reservationViewNavigationService = reservationViewNavigationService;

        // Подписка на изменение свойств в модели резервирования номеров
        _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    /// <summary> Проверка на изменение свойств в модели MakeReservationViewModel </summary>
    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(MakeReservationViewModel.UserName) ||
            e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            OnCanExecutedChanged();
    }

    public override bool CanExecute(object? parameter) {
        return !string.IsNullOrEmpty(_makeReservationViewModel.UserName) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
    }

    public override async Task ExecuteAsync(object? parameter) {
        Reservation reservation = new Reservation(
            new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
            _makeReservationViewModel.UserName,
            _makeReservationViewModel.StartDate,
            _makeReservationViewModel.EndDate
        );

        try {
            // await _hotel.MakeReservation(reservation); - переехал в HotelStore в ленивую загрузку
            await _hotelStore.MakeReservation(reservation);

            MessageBox.Show("Комната забронирована", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);

            // _reservationViewNavigationService.Navigate();
        }
        catch (ReservationConflictException exp) {
            MessageBox.Show($"Комната уже забронирована\n{exp.Message}", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex) {
            MessageBox.Show($"{ex.Message}", "Error",
            MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }

    /// <summary>
    /// Если поля в форме бронирования не заданы, то кнопка "отправить" не активна
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns>Команда может быть выполнена, только если заданы валидные значения</returns>
    //public override bool CanExecute(object? parameter) {
    //    return !string.IsNullOrEmpty(_makeReservationViewModel.UserName) &&
    //            _makeReservationViewModel.FloorNumber > 0 &&
    //            base.CanExecute(parameter);
    //}

    //public override void Execute(object? parameter) {
    //    Reservation reservation = new Reservation(
    //        new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
    //        _makeReservationViewModel.UserName,
    //        _makeReservationViewModel.StartDate,
    //        _makeReservationViewModel.EndDate
    //    );

    //    try {
    //        _hotel.MakeReservation(reservation);
    //        MessageBox.Show("Комната забронирована", "Success", 
    //            MessageBoxButton.OK, MessageBoxImage.Information);

    //        _reservationViewNavigationService.Navigate();
    //    }
    //    catch (ReservationConflictException exp) {
    //        MessageBox.Show("Комната уже забронирована", "Error", 
    //            MessageBoxButton.OK, MessageBoxImage.Error);
    //    }

    //}
}
