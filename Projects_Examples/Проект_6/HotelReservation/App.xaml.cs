using HotelReservation.DbContexts;
using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Services.ReservationConflictValidators;
using HotelReservation.Services.ReservationCreators;
using HotelReservation.Services.ReservationProviders;
using HotelReservation.Stores;
using HotelReservation.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace HotelReservation;

public partial class App : Application {

    private const string CONNECTION_STRING = "Data Source=reservoom.db";
    private readonly IHost _host;

    //private readonly Hotel _hotel;
    //private readonly HotelStore _hotelStore;
    //private readonly NavigationStore _navigationStore;
    //private readonly ReservoomDbContextFactory _reservoomDbContextFactory;

    public App() {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services => {
                services.AddSingleton(new ReservoomDbContextFactory(CONNECTION_STRING));
                services.AddSingleton<IReservationProvider, DatabaseReservationProvider>();
                services.AddSingleton<IReservationCreator, DatabaseReservationCreator>();
                services.AddSingleton<IReservationConflictValidator, DatabaseReservationConflictValidator>();

                services.AddTransient<ReservationBook>();
                services.AddSingleton((s) => new Hotel("SingletonSean Suites", s.GetRequiredService<ReservationBook>()));

                services.AddTransient<ReservationListingViewModel>();
                services.AddSingleton<Func<ReservationListingViewModel>>((s) => () => s.GetRequiredService<ReservationListingViewModel>());
                services.AddSingleton<NavigationService<ReservationListingViewModel>>();

                services.AddTransient<MakeReservationViewModel>();
                services.AddSingleton<Func<MakeReservationViewModel>>((s) => () => s.GetRequiredService<MakeReservationViewModel>());
                services.AddSingleton<NavigationService<MakeReservationViewModel>>();

                services.AddSingleton<HotelStore>();
                services.AddSingleton<NavigationStore>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton((s) => new MainWindow {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e) {
        _host.Start();

        ReservoomDbContextFactory reservoomDbContextFactory = 
            _host.Services.GetRequiredService<ReservoomDbContextFactory>();

        using (ReservoomDbContext dbContext = reservoomDbContextFactory.CreateDbContext()) {
            dbContext.Database.Migrate();
        }

        // _navigationStore.CurrentViewModel = CreateReservationListingViewModel();
        // _navigationStore.CurrentViewModel = CreateReservationViewModel();

        //NavigationStore navigationStore = _host.Services.GetRequiredService<NavigationStore>();
        //navigationStore.CurrentViewModel = CreateReservationViewModel();

        NavigationService<ReservationListingViewModel> navigationService =
            _host.Services.GetRequiredService<NavigationService<ReservationListingViewModel>>();
        
        navigationService.Navigate();

        //MainWindow = new MainWindow { DataContext = new MainViewModel(_navigationStore) };

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
        
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e) {
        _host.Dispose();
        base.OnExit(e);
    }

    /// <summary> Создает модель - представление формы создания списка бронирования номеров </summary>
    //private MakeReservationViewModel CreateMakeReservationViewModel() {
    //    return new MakeReservationViewModel(_hotelStore, new NavigationService(_navigationStore, CreateReservationViewModel));
    //}

    ///// <summary> Создает модель - представление бронирования номеров </summary>
    //private ReservationListingViewModel CreateReservationViewModel() {
    //    return ReservationListingViewModel.LoadViewModel(_hotelStore, CreateMakeReservationViewModel(),
    //           new NavigationService(_navigationStore, CreateMakeReservationViewModel));
    //}
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