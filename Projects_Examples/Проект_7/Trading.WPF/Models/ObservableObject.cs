using System.ComponentModel;

namespace Trading.WPF.Models;

/// <summary> Наблюдаемый объект </summary>
public class ObservableObject : INotifyPropertyChanged {

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
