using StartUpMVVM.Infrastructure.Commands.Base;
using StartUpMVVM.Views.Windows;
using System.Windows;

namespace StartUpMVVM.Infrastructure.Commands;

class ManageStudentsCommand : Command {

    private StudentsManagementWindow? _Window;

    public override bool CanExecute(object? parameter) => _Window == null;

    public override void Execute(object? parameter) {
        var window = new StudentsManagementWindow {
            Owner = Application.Current.MainWindow
        };
        _Window = window;
        window.Closed += OnWindowClosed;

        window.ShowDialog();
    }

    private void OnWindowClosed(object? sender, EventArgs e) {
        if (sender != null)
            ((Window)sender).Closed -= OnWindowClosed;
        _Window = null;
    }
}
