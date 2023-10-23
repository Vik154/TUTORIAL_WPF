namespace ContactBook.Services;

/// <summary> Сервис по работе с пользователем </summary>
public interface IDialogService {
    string? OpenFile(string filter);
    void ShowMessageBox(string message);
}
