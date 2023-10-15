using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace HotelReservation.Commands;

/// <summary> Команда бронирования номеров </summary>
public class MakeReservationCommand : BaseCommand {

    private readonly MakeReservationViewModel _makeReservationViewModel;
    private readonly Hotel _hotel;
    public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel) {
        _makeReservationViewModel = makeReservationViewModel;
        _hotel = hotel;

        // Подписка на изменение свойств в модели резервирования номеров
        _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    /// <summary> Проверка на изменение свойств в модели MakeReservationViewModel </summary>
    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == nameof(MakeReservationViewModel.UserName) ||
            e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            OnCanExecutedChanged();
    }

    /// <summary>
    /// Если поля в форме бронирования не заданы, то кнопка "отправить" не активна
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns>Команда может быть выполнена, только если заданы валидные значения</returns>
    public override bool CanExecute(object? parameter) {
        return !string.IsNullOrEmpty(_makeReservationViewModel.UserName) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
    }

    public override void Execute(object? parameter) {
        Reservation reservation = new Reservation(
            new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
            _makeReservationViewModel.UserName,
            _makeReservationViewModel.StartDate,
            _makeReservationViewModel.EndDate
        );

        try {
            _hotel.MakeReservation(reservation);
            MessageBox.Show("Комната забронирована", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (ReservationConflictException exp) {
            MessageBox.Show("Комната уже забронирована", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
