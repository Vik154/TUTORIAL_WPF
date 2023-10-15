using HotelReservation.Services;
using HotelReservation.Stores;
using HotelReservation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Commands;

/// <summary> Команда отвечающая за переключение между моделями - представлений </summary>
public class NavigateCommand : BaseCommand {

    private readonly NavigationService _navigationService;

    public NavigateCommand(NavigationService navigation) {
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
