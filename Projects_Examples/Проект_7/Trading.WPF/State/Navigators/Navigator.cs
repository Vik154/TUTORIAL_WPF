using System.ComponentModel;
using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.Models;
using Trading.WPF.ViewModels;
using Trading.WPF.ViewModels.Factories;

namespace Trading.WPF.State.Navigators;

/// <summary>Реализация логики навигации между представлениями</summary>
public class Navigator : ObservableObject, INavigator {

    private BaseViewModel _currentViewModel;

    public BaseViewModel CurrentViewModel {
        get => _currentViewModel;
        set {
            _currentViewModel?.Dispose();

            _currentViewModel = value;
            StateChanged?.Invoke();
        }
    }

    public event Action StateChanged;

    // public ICommand UpdateCurrentViewModelCommand {  get; set; }

    //public Navigator(IRootSimpleTraderViewModelFactory viewModelAbstractFactory)
    //{
    //    UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelAbstractFactory);
    //}

}