using ContactBook.Utility;

namespace ContactBook.ViewModels;

public class MainViewModel : ObservableObject {

    private string _titleWindow = "Книга контактов";
    public string TitleWindow {
        get => _titleWindow;
        set => OnPropertyChanged(ref  _titleWindow, value);
    }

}
