using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xaml;


namespace StartUpMVVM.ViewModels.Base;

// ViewModelBase
internal abstract class ViewModel : MarkupExtension, INotifyPropertyChanged, IDisposable {

    // Событие, возникающее при изменении свойств
    public event PropertyChangedEventHandler? PropertyChanged;

    // Атрибут CallerMemberName - позволяет не указывать имя свойства, компилятор автоматически
    // подставит в propertyName имя метода из которого вызывается процедура
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        var handlers = PropertyChanged;
        if (handlers is null) return;

        var invocation_list = handlers.GetInvocationList();

        var arg = new PropertyChangedEventArgs(propertyName);
        foreach (var action in invocation_list)
            if (action.Target is DispatcherObject disp_object)
                disp_object.Dispatcher.Invoke(action, this, arg);
            else
                action.DynamicInvoke(this, arg);
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

    // Теперь viewmodel стала расширением разметки
    public override object ProvideValue(IServiceProvider sp) {
        
        // Целевой объект к которому выполняется обращение 
        var value_target_service = sp.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
       
        // Корень дерева - окно (mainWindow)
        var root_object_service = sp.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

        OnInitialized(
            value_target_service?.TargetObject,
            value_target_service?.TargetProperty,
            root_object_service?.RootObject);

        return this;
    }

    private WeakReference? _TargetRef;  // Ссылка на целевой объект
    private WeakReference? _RootRef;    // Ссылка на корень

    public object? TargetObject => _TargetRef?.Target;

    public object? RootObject => _RootRef?.Target;

    protected virtual void OnInitialized(object? Target, object? Property, object? Root) {
        _TargetRef = new WeakReference(Target);
        _RootRef = new WeakReference(Root);
    }
}
