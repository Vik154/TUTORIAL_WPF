using ContactBook.Utility;

namespace ContactBook.ViewModels;

public class BookViewModel : ObservableObject {

    /// <summary> Заголовок главного окна </summary>
    private string _title = "Книга";

    /// <summary> Заголовок главного окна </summary>
    public string Title {
        get => _title;
        set => OnPropertyChanged(ref _title, value);
    }
}
