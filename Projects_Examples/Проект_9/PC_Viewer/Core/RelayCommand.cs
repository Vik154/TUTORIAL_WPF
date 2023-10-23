using System.Windows.Input;

namespace PC_Viewer.Core;

public class RelayCommand : ICommand {
    private readonly Action<object> _Execute;
    private readonly Func<object, bool>? _CanExecute;

    public event EventHandler? CanExecuteChanged {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public RelayCommand(Action Execute, Func<bool>? CanExecute = null)
        : this(p => Execute(), CanExecute is null ? (Func<object, bool>?)null : p => CanExecute()) { }

    public RelayCommand(Action<object> Execute, Func<object, bool>? CanExecute = null) {
        _Execute = Execute;
        _CanExecute = CanExecute;
    }

    public bool CanExecute(object? p) => _CanExecute?.Invoke(p) ?? true;

    public void Execute(object? p) => _Execute(p);
}
