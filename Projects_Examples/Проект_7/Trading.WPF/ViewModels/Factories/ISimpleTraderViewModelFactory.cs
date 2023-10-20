using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public interface ISimpleTraderViewModelFactory<T> where T : BaseViewModel {
    T CreateViewModel();
}
