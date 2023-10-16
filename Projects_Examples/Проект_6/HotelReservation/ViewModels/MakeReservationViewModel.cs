using HotelReservation.Commands;
using HotelReservation.Services;
using HotelReservation.Stores;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

/// <summary> Модель - представление для работы с формой бронирования номеров </summary>
public class MakeReservationViewModel : BaseViewModel, INotifyDataErrorInfo {

    #region СВОЙСТВА

    /// <summary> Имя пользователя </summary>
    private string _userName = "";

    /// <summary> Имя пользователя </summary>
    public string UserName {
		get => _userName;
		set { 
            _userName = value; 
            OnPropertyChanged(nameof(UserName));

            ClearErrors(nameof(UserName));
            if (!HasUserName) { AddError("Имя пользователя не должно быть пустым", nameof(UserName)); }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
	}

    /// <summary> Номер комнаты отеля </summary>
    private int _roomNumber;

    /// <summary> Номер комнаты отеля </summary>
	public int RoomNumber {
		get => _roomNumber;
		set { 
            _roomNumber = value;
            OnPropertyChanged(nameof(RoomNumber)); 
        }
	}

    /// <summary> Номер этажа отеля </summary>
    private int _floorNumber = 1;

    /// <summary> Номер этажа отеля </summary>
    public int FloorNumber {
        get => _floorNumber;
        set { 
            _floorNumber = value; 
            OnPropertyChanged(nameof(FloorNumber));

            ClearErrors(nameof(FloorNumber));

            if (!HasFloorNumberGreaterThanZero) {
                AddError("Номер этажа должен быть больше нуля.", nameof(FloorNumber));
            }
            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    /// <summary> Время начала брони </summary>
    private DateTime _startDate = new DateTime(2023, 1, 1);

    /// <summary> Время начала брони </summary>
    public DateTime StartDate {
        get => _startDate;
        set { 
            _startDate = value; 
            OnPropertyChanged(nameof(StartDate));

            ClearErrors(nameof(StartDate));
            ClearErrors(nameof(EndDate));

            if (!HasStartDateBeforeEndDate) {
                AddError("Дата начала не может быть меньше даты окончания.", nameof(StartDate));
            }

            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    /// <summary> Время окончания брони </summary>
    private DateTime _endDate = new DateTime(2021, 1, 8);

    /// <summary> Время окончания брони </summary>
    public DateTime EndDate {
        get => _endDate;
        set {
            _endDate = value; 
            OnPropertyChanged(nameof(EndDate));

            ClearErrors(nameof(StartDate));
            ClearErrors(nameof(EndDate));

            if (!HasStartDateBeforeEndDate) {
                AddError("Дата окончания не может быть меньше даты начала.", nameof(EndDate));
            }

            OnPropertyChanged(nameof(CanCreateReservation));
        }
    }

    public bool CanCreateReservation =>
            HasUserName &&
            HasFloorNumberGreaterThanZero &&
            HasStartDateBeforeEndDate &&
            !HasErrors;

    private bool HasUserName => !string.IsNullOrEmpty(UserName);
    private bool HasFloorNumberGreaterThanZero => FloorNumber > 0;
    private bool HasStartDateBeforeEndDate => StartDate < EndDate;

    private string _submitErrorMessage = "";
    public string SubmitErrorMessage {
        get {
            return _submitErrorMessage;
        }
        set {
            _submitErrorMessage = value;
            OnPropertyChanged(nameof(SubmitErrorMessage));
            OnPropertyChanged(nameof(HasSubmitErrorMessage));
        }
    }

    public bool HasSubmitErrorMessage => !string.IsNullOrEmpty(SubmitErrorMessage);

    private bool _isSubmitting;
    public bool IsSubmitting {
        get {
            return _isSubmitting;
        }
        set {
            _isSubmitting = value;
            OnPropertyChanged(nameof(IsSubmitting));
        }
    }

    #endregion

    #region КОМАНДЫ

    /// <summary> Отправить </summary>
    public AsyncCommandBase SubmitCommand { get; }

    /// <summary> Закрыть </summary>
    public ICommand CancelCommand { get; }

    #endregion

    #region Интерфейс INotifyDataErrorInfo и логика работы с ошибками

    /// <summary> Информация об ошибках, реализация INotifyDataErrorInfo </summary>
    private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

    public bool HasErrors => _propertyNameToErrorsDictionary.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName) {
        if (propertyName is null) {
            MessageBox.Show($"Пустое имя свойства {nameof(propertyName)}");
            return Enumerable.Empty<string>();
        }
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
    
    public MakeReservationViewModel(HotelStore hotelStore, NavigationService<ReservationListingViewModel> reservationViewNavigationService) 
    {
        SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
        CancelCommand = new NavigateCommand<ReservationListingViewModel>(reservationViewNavigationService);
        _propertyNameToErrorsDictionary = new();
    }

}
