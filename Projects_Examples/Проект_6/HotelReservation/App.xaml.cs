using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using HotelReservation.ViewModels;
using System.Windows;

namespace HotelReservation;

public partial class App : Application {

    private readonly Hotel _hotel;
    private readonly NavigationStore _navigationStore;

    public App() {
        _hotel = new Hotel("SingletonSean Suites");
        _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e) {

        _navigationStore.CurrentViewModel = CreateReservationListingViewModel();

        MainWindow = new MainWindow {
            DataContext = new MainViewModel(_navigationStore)
        };
        MainWindow.Show();
        
        base.OnStartup(e);
    }

    /// <summary> Создает модель - представление формы создания списка бронирования номеров </summary>
    private MakeReservationViewModel CreateMakeReservationViewModel() {
        return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationListingViewModel));
    }

    /// <summary> Создает модель - представление бронирования номеров </summary>
    private ReservationListingViewModel CreateReservationListingViewModel() {
        return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
    }
}

// Тестирование корректной проверки при RoomID == null 
//protected override void OnStartup(StartupEventArgs e) {
//    Hotel hotel = new Hotel("SingletonSean Suites");

//    try {
//        hotel.MakeReservation(new Reservation(
//            new RoomID(1, 1),
//            "SingletonSean",
//            new DateTime(2000, 1, 1),
//            new DateTime(2000, 1, 2)));

//        hotel.MakeReservation(new Reservation(
//            new RoomID(1, 1),
//            "SingletonSean",
//            new DateTime(2000, 1, 1),
//            new DateTime(2000, 1, 4)));
//    }
//    catch (ReservationConflictException ex) {
//        // Thread.Sleep(1000);
//    }

//    IEnumerable<Reservation> reservations = hotel.GetAllReservations();

//    base.OnStartup(e);
//}