using System.Windows.Input;
using Trading.WPF.ViewModels;

namespace Trading.WPF.State.Navigators;

/// <summary> Интерфейс навигации между представлениями </summary>
public interface INavigator {

    /// <summary> Указатель на базовый класс моделей - представления </summary>
    BaseViewModel CurrentViewModel { get; set; }

    /// <summary> Указатель на базовый интерфейс навигационной команды </summary>
    ICommand UpdateCurrentViewModelCommand { get; }
}

/// <summary> Перечисление представлений </summary>
public enum ViewType { Home, Portfolio, Buy }