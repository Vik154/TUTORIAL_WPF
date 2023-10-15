using HotelReservation.Commands;
using HotelReservation.Models;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

public class MakeReservationViewModel : BaseViewModel {

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
        set { _endDate = value; OnPropertyChanged(nameof(EndDate)); }
    }

    #endregion

    #region КОМАНДЫ

    /// <summary> Отправить </summary>
    public ICommand SubmitCommand { get; }

    /// <summary> Закрыть </summary>
    public ICommand CancelCommand { get; }


    #endregion

    public MakeReservationViewModel(Hotel hotel) {
        SubmitCommand = new MakeReservationCommand(this, hotel);
    }
}
