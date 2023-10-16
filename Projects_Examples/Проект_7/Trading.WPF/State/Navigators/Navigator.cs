using System.ComponentModel;
using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.Models;
using Trading.WPF.ViewModels;

namespace Trading.WPF.State.Navigators;

/// <summary>Реализация логики навигации между представлениями</summary>
public class Navigator : ObservableObject, INavigator {

    private BaseViewModel _currentViewModel;

    public BaseViewModel CurrentViewModel {
        get => _currentViewModel;
        set {
            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

}