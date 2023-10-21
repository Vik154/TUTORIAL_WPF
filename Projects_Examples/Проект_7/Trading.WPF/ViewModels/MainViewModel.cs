﻿using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;
using Trading.WPF.ViewModels.Factories;

namespace Trading.WPF.ViewModels;

public class MainViewModel : BaseViewModel {

    private readonly ISimpleTraderViewModelFactory _viewModelFactory;
    private readonly INavigator _navigator;
    private readonly IAuthenticator _authenticator;

    public bool IsLoggedIn => _authenticator.IsLoggedIn;
    public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;

    public ICommand UpdateCurrentViewModelCommand { get; }

    public MainViewModel(INavigator navigator, 
        ISimpleTraderViewModelFactory viewModelFactory, 
        IAuthenticator authenticator) 
    {
        _navigator = navigator;
        _viewModelFactory = viewModelFactory;
        _authenticator = authenticator;

        _navigator.StateChanged += Navigator_StateChanged;
        _authenticator.StateChanged += Authenticator_StateChanged;

        UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
        UpdateCurrentViewModelCommand.Execute(ViewType.Login);
    }

    private void Authenticator_StateChanged() {
        OnPropertyChanged(nameof(IsLoggedIn));
    }

    private void Navigator_StateChanged() {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    public override void Dispose() {
        _navigator.StateChanged -= Navigator_StateChanged;
        _authenticator.StateChanged -= Authenticator_StateChanged;

        base.Dispose();
    }
}
