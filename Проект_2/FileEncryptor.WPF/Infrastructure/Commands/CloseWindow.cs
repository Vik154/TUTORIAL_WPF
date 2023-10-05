using FileEncryptor.WPF.Infrastructure.Commands.Base;
using System.Windows;

namespace FileEncryptor.WPF.Infrastructure.Commands;

internal class CloseWindow : Command {

    protected override void Execute(object? parameter) =>
        (parameter as Window ?? App.FocusedWindow ?? App.ActivedWindow)?.Close();
}
