using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public interface IRootSimpleTraderViewModelFactory {
    BaseViewModel CreateViewModel(ViewType viewType);

}
