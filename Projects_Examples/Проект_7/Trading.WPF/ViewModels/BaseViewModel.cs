using System.ComponentModel;

namespace Trading.WPF.ViewModels;

/// <summary> Вместо фабрик </summary>
public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

public class BaseViewModel : INotifyPropertyChanged {
    public virtual void Dispose() { }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}