using System.ComponentModel;

namespace HotelReservation.ViewModels;

/// <summary> Базовая модель - представления </summary>
public class BaseViewModel : INotifyPropertyChanged {

    /// <summary> Событие генерируемое при изменении свойств </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary> Метод, вызывающий событие при изменении свойств </summary>
    /// <param name="propertyName"></param>
    protected void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary> Освобождение захваченных ресурсов, реализуется в наследниках </summary>
    public virtual void Dispose() { }
}
