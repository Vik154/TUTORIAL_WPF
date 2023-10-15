using HotelReservation.Stores;
using HotelReservation.ViewModels;

namespace HotelReservation.Services;

/// <summary> Сервис для переключения моделей - представления </summary>
/// <typeparam name="TViewModel"></typeparam>
public class NavigationService {
    private readonly NavigationStore _navigationStore;
    private readonly Func<BaseViewModel> _createViewModel;

    public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> createViewModel) {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate() {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}
