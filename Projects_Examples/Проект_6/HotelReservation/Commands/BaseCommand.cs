using System.Windows.Input;

namespace HotelReservation.Commands;

public abstract class BaseCommand : ICommand {
    public event EventHandler? CanExecuteChanged;
    public virtual bool CanExecute(object? parameter) => true;
    public abstract void Execute(object? parameter);
    protected void OnCanExecutedChanged() => CanExecuteChanged?.Invoke(this, new EventArgs());
}
