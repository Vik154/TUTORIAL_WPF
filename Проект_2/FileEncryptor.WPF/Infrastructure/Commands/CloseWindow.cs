using FileEncryptor.WPF.Infrastructure.Commands.Base;
using System.Windows;

namespace FileEncryptor.WPF.Infrastructure.Commands;


// Команда закрытия окна
internal class CloseWindow : Command {

    protected override bool CanExecute(object? parameter) =>
        (parameter as Window ?? App.FocusedWindow ?? App.ActivedWindow) != null;

    protected override void Execute(object? parameter) =>
        (parameter as Window ?? App.FocusedWindow ?? App.ActivedWindow)?.Close();
}
