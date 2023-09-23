using System;
using System.Windows.Input;

namespace _07_Commands;

public class CustomCommand : ICommand {

    // Когда срабатывает команда, метод CommandExecute (который в MainWindow Находится)
    // будет сообщен с этим делегатом
    private readonly Action<object>    _execute;

    // Будет сообщен с методом CanCommandExecute (находится в MainWindow),
    // который проверяет может ли команда выполняться
    private readonly Predicate<object> _canExecute;

    public CustomCommand(Action<object> execute, Predicate<object> canExecute) {

        if (canExecute == null)
            throw new ArgumentNullException("execute");

        _execute = execute;
        _canExecute = canExecute;
    }

    public CustomCommand(Action<object> execute) : this(execute, null) { }

    // Реализация события
    public event EventHandler? CanExecuteChanged {
        add    { CommandManager.RequerySuggested += value; }
        remove {  CommandManager.RequerySuggested -= value;}
    }

    // Реализация метода интерфейса ICommand, возвращает true / false, т.е.
    // Может ли быть выполнен метод Execute
    public bool CanExecute(object? parameter) {
        // Если _canExecute не равен null - вызывается делегат _canExecute
        return _canExecute == null ? true : _canExecute.Invoke(parameter);
    }

    // Вызывает делегат Action с параметром parametr, т.е. метод CommandExecute,
    // который определен в MainWindow
    public void Execute(object? parameter) {
        _execute.Invoke(parameter);
    }
}
