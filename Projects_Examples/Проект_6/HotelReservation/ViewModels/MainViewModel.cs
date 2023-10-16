using HotelReservation.Stores;

namespace HotelReservation.ViewModels;

/// <summary> Основная модель - представления </summary>
public class MainViewModel : BaseViewModel {

    /// <summary> Навигация по моделям </summary>
    private readonly NavigationStore _navigationStore;

    /// <summary> Базовая модель - представления для хранения наследников, для навигации </summary>
    public BaseViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore) {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged; 
    }

    private void OnCurrentViewModelChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
