using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace StartUpMVVM.ViewModels.Base;

// ViewModelBase
internal abstract class ViewModel : INotifyPropertyChanged, IDisposable {

    // Событие, возникающее при изменении свойств
    public event PropertyChangedEventHandler? PropertyChanged;

    // Атрибут CallerMemberName - позволяет не указывать имя свойства, компилятор автоматически
    // подставит в propertyName имя метода из которого вызывается процедура
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Метод, устанавливающий новое значение свойства, field - ссылка на поле свойства,
    // value - новое значение, и имя свойства - propertyName
    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {

        // Защита от кольцевых обновлений свойств (если одно обновляет другое, а то третье и т.д.)
        if (Equals(field, value)) return false;

        // Если значение свойства изменилось
        field = value;                      // обновляется поле field
        OnPropertyChanged(propertyName);    // Генерируется событие
        return true;                        // Флаг для отслеживания изменилось ли свойство 
    }

    // Для примера
    public void Dispose() {
        Dispose(true);
    }

    private bool _Disposed;

    // Освобождение управляемых ресурсов
    protected virtual void Dispose(bool disposing) {
        if (!disposing || _Disposed)
            return;
        _Disposed = true;
    }

    // ~ViewModel() { Dispose(false); }
}
