using MathCore.ViewModels;


namespace Bookinist.ViewModels; 

class MainWindowViewModel : ViewModel {

    #region Title - заголовок окна
    /// <summary> Заголовок окна </summary>
    private string? _Title;

    /// <summary> Заголовок окна </summary>
    public string? Title {
        get => _Title;
        set => Set(ref _Title, value);
    }
    #endregion
}
