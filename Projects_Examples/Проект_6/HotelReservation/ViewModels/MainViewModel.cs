using HotelReservation.Models;
using HotelReservation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.ViewModels;

public class MainViewModel : BaseViewModel {

    /// <summary> Навигация по моделям </summary>
    private readonly NavigationStore _navigationStore;

    /// <summary> Базовая модель - представления для хранения наследники </summary>
    public BaseViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore) {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged; 
    }

    private void OnCurrentViewModelChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
