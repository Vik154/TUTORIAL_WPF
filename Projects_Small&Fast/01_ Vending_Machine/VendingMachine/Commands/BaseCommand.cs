using System.Windows.Input;

namespace VendingMachine.Commands;

public abstract class BaseCommand : ICommand {
    private bool _Executable = true;

    public bool Executable {
        get => _Executable;
        set {
            if (_Executable == value) return;
            _Executable = value;
            ExecutableChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public event EventHandler? ExecutableChanged;

    event EventHandler? ICommand.CanExecuteChanged {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    bool ICommand.CanExecute(object? parameter) {
        return _Executable && CanExecute(parameter);
    }

    void ICommand.Execute(object? parameter) {
        if (!((ICommand)this).CanExecute(parameter))
            return;
        Execute(parameter);
    }

    protected virtual bool CanExecute(object p) => true;

    protected abstract void Execute(object p);
}
