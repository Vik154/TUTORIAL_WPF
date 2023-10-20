using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public interface ISimpleTraderViewModelAbstractFactory {
    BaseViewModel CreateViewModel(ViewType viewType);

}
