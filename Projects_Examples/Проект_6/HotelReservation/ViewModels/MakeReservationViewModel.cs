using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

public class MakeReservationViewModel : BaseViewModel, INotifyDataErrorInfo {

    #region СВОЙСТВА

    /// <summary> Имя пользователя </summary>
    private string _userName = "";

    /// <summary> Имя пользователя </summary>
    public string UserName {
		get => _userName;
		set { _userName = value; OnPropertyChanged(nameof(UserName)); }
	}

    /// <summary> Номер комнаты отеля </summary>
    private int _roomNumber;

    /// <summary> Номер комнаты отеля </summary>
	public int RoomNumber {
		get => _roomNumber;
		set { _roomNumber = value; OnPropertyChanged(nameof(RoomNumber)); }
	}

    /// <summary> Номер этажа отеля </summary>
    private int _floorNumber;

    /// <summary> Номер этажа отеля </summary>
    public int FloorNumber {
        get => _floorNumber;
        set { _floorNumber = value; OnPropertyChanged(nameof(FloorNumber)); }
    }

    /// <summary> Время начала брони </summary>
    private DateTime _startDate = new DateTime(2021, 1, 1);

    /// <summary> Время начала брони </summary>
    public DateTime StartDate {
        get => _startDate;
        set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
    }

    /// <summary> Время окончания брони </summary>
    private DateTime _endDate = new DateTime(2021, 1, 8);

    /// <summary> Время окончания брони </summary>
    public DateTime EndDate {
        get => _endDate;
        set {
            _endDate = value; 
            OnPropertyChanged(nameof(EndDate)); 
            
            _propertyNameToErrorsDictionary.Remove(nameof(EndDate));

            if (EndDate < StartDate) {
                List<string> endDateErrors = new() { "Дата окончания не может быть меньше даты начала" };
                _propertyNameToErrorsDictionary.Add(nameof(EndDate), endDateErrors);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(EndDate)));
            }
        }
    }

    #endregion

    #region КОМАНДЫ

    /// <summary> Отправить </summary>
    public ICommand SubmitCommand { get; }

    /// <summary> Закрыть </summary>
    public ICommand CancelCommand { get; }

    #endregion

    #region Интерфейс INotifyDataErrorInfo и логика работы с ошибками
    /// <summary> Информация об ошибках, реализация INotifyDataErrorInfo </summary>
    private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

    public bool HasErrors => _propertyNameToErrorsDictionary.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    public IEnumerable GetErrors(string? propertyName) {
        if (propertyName is null) 
            throw new ArgumentNullException(nameof(propertyName));
        return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
    }

    private void AddError(string errorMessage, string propertyName) {
        if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName)) {
            _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
        }

        _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

        OnErrorsChanged(propertyName);
    }

    private void ClearErrors(string propertyName) {
        _propertyNameToErrorsDictionary.Remove(propertyName);

        OnErrorsChanged(propertyName);
    }

    private void OnErrorsChanged(string propertyName) {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    #endregion
    
    public MakeReservationViewModel(HotelStore hotelStore, NavigationService reservationViewNavigationService) {
        SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
        CancelCommand = new NavigateCommand(reservationViewNavigationService);
        _propertyNameToErrorsDictionary = new();
    }

}
