using StartUpMVVM.Infrastructure.Commands.Base;
using System.Windows;


namespace StartUpMVVM.Infrastructure.Commands;

// Вынос команд в отдельные классы
internal class CloseApplicationCommand : Command {
    public override bool CanExecute(object? parameter) => true;
    public override void Execute(object? parameter) => Application.Current.Shutdown();
}
