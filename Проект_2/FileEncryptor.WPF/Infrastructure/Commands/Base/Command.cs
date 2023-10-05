using System.Windows.Input;

namespace FileEncryptor.WPF.Infrastructure.Commands.Base;

// Базовая логика команды
internal abstract class Command : ICommand {

    public event EventHandler? CanExecuteChanged {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    // Дополнительное свойство - которое включает или выключает команду целиком
    private bool _Executable = true;
    public bool Executable {
        get => _Executable;
        set {
            if (_Executable == value)
                return;
            _Executable = value;
            CommandManager.InvalidateRequerySuggested();
        }
    }

    // Неявная реализация методов команды (позволяет создать дополнительное свойства)
    bool ICommand.CanExecute(object? parameter) => _Executable && CanExecute(parameter);
    
    void ICommand.Execute(object? parameter) {
        if (CanExecute(parameter))      // Если команду можно выполнить - тогда выполнить
            Execute(parameter);         // помогает избавиться от лишних проверок в наследниках
    }

    // Всегда возвращает true, если не переопределен наследником
    protected virtual bool CanExecute(object? parameter) => true;

    // Наследник должен реализовать собственную логику этого метода
    protected abstract void Execute(object? parameter);
}
