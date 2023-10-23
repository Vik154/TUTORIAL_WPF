using Microsoft.Win32;

namespace ContactBook.Services;

/// <summary> Диалоговое окно в стиле WinApi </summary>
public class WindowDialogService : IDialogService {
    public string? OpenFile(string filter) {
        var dialog = new OpenFileDialog();

        if (dialog.ShowDialog() == true) {
            return dialog.FileName;
        }

        return null;
    }

    public void ShowMessageBox(string message) {
        throw new NotImplementedException();
    }
}
