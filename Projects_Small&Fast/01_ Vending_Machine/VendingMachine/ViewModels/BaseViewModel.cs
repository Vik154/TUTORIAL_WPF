using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VendingMachine.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged {

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
}
