namespace VendingMachine.Commands;

public class ActionCommand : BaseCommand {
    private readonly Action<object> _Execute;
    private readonly Func<object, bool>? _CanExecute;

    public ActionCommand(Action Execute, Func<bool>? CanExecute = null)
        : this(p => Execute(), CanExecute is null ? (Func<object, bool>?)null : p => CanExecute()) { }

    public ActionCommand(Action<object> Execute, Func<object, bool>? CanExecute = null) {
        _Execute = Execute;
        _CanExecute = CanExecute;
    }

    protected override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

    protected override void Execute(object p) => _Execute(p);
}
