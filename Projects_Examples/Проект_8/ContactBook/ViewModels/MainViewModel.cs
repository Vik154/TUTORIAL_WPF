using ContactBook.Utility;

namespace ContactBook.ViewModels;

public class MainViewModel : ObservableObject {

    #region ПОЛЯ

    #endregion

    #region СВОЙСТВА

    /// <summary> Заголовок главного окна </summary>
    private string _titleWindow = "Книга контактов";

    /// <summary> Заголовок главного окна </summary>
    public string TitleWindow {
        get => _titleWindow;
        set => OnPropertyChanged(ref  _titleWindow, value);
    }

    /// <summary> Текущее представление </summary>
    private object? _currentView;

    /// <summary> Текущее представление </summary>
    public object? CurrentView {
        get => _currentView;
        set => OnPropertyChanged(ref _currentView, value);
    }

    /// <summary> Модель представление - записной книги </summary>
    private BookViewModel? _bookViewModel;

    /// <summary> Модель представление - записной книги </summary>
    public BookViewModel? BookViewModel {
        get => _bookViewModel;
        set => OnPropertyChanged(ref _bookViewModel, value);
    }

    #endregion

    public MainViewModel() {
        BookViewModel = new BookViewModel();
        CurrentView = BookViewModel;
    }

}
