using System.Windows.Input;

namespace TestTemplateMVVM.Infrastructure.Commands.Base;


internal abstract class CommandAsync : ICommand {

    private bool _Executable = true;

    public bool Executable {
        get => _Executable;
        set {
            if (_Executable == value) return;
            _Executable = value;
            ExecutableChanged?.Invoke(this, EventArgs.Empty);
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public event EventHandler? ExecutableChanged;

    event EventHandler? ICommand.CanExecuteChanged {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    bool ICommand.CanExecute(object? parameter) {
        if (parameter is null)
            throw new ArgumentNullException("Передан не валидный параметр в команду");
        return _Executable && CanExecute(parameter);
    }

    async void ICommand.Execute(object? parameter) {
        if (!((ICommand)this).CanExecute(parameter)) 
            return;
        if (parameter is null)
            throw new ArgumentNullException("Передан не валидный параметр в команду");

        try {
            Executable = false;
            await ExecuteAsync(parameter);
        }
        catch {
            Executable = true;
            throw;
        }
    }

    protected virtual bool CanExecute(object p) => true;

    protected abstract Task ExecuteAsync(object p);
}
