using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public interface ISimpleTraderViewModelFactory {
    BaseViewModel CreateViewModel(ViewType viewType);

}
