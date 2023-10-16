using HotelReservation.Services;
using HotelReservation.ViewModels;

namespace HotelReservation.Commands;

/// <summary> Команда отвечающая за переключение между моделями - представлений </summary>
public class NavigateCommand<TViewModel> : BaseCommand where TViewModel : BaseViewModel {

    private readonly NavigationService<TViewModel> _navigationService;

    public NavigateCommand(NavigationService<TViewModel> navigation) {
        _navigationService = navigation;        
    }

    public override void Execute(object? parameter) {
        _navigationService.Navigate();
    }

    /* До сервисов
     /// <summary> Хранит view models для навигации по ним </summary>
    private readonly NavigationStore _navigationStore;

    /// <summary> Указатель на функцию, которая позволяет переключаться между view models </summary>
    private readonly Func<BaseViewModel> _viewModelFactory;

    public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> viewModelFactory) {
        _navigationStore = navigationStore;
        _viewModelFactory = viewModelFactory;
    }
    */
}
