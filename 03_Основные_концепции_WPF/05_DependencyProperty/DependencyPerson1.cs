using System.Windows;

namespace _05_DependencyProperty;

class DependencyPerson1 : DependencyObject {

    public static readonly DependencyProperty IdProperty;
    public static readonly DependencyProperty NameProperty;
    public static readonly DependencyProperty AgeProperty;

    static DependencyPerson1() {
        IdProperty = DependencyProperty
            .Register("Id"
                     ,typeof(int)
                     ,typeof(DependencyPerson1)
                     ,new FrameworkPropertyMetadata(defaultValue:0)
                     ,new ValidateValueCallback(IsValidRange));
        
        NameProperty = DependencyProperty
            .Register("Name"
                     ,typeof(string)
                     ,typeof(DependencyPerson1)
                     ,new FrameworkPropertyMetadata(defaultValue: string.Empty)
                     ,new ValidateValueCallback(IsValidLenght));
        
        AgeProperty = DependencyProperty
            .Register("Age"
                     ,typeof(int)
                     ,typeof(DependencyPerson1)
                     ,new FrameworkPropertyMetadata(defaultValue:0)
                     ,new ValidateValueCallback(IsValidRange));
    }

    // Обычное свойство - обертка, над свойством зависимостей
    public int Id {
        get { return (int)GetValue(IdProperty); }
        set { SetValue(IdProperty, value); }
    }

    // Обычное свойство - обертка, над свойством зависимостей
    public string Name {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }

    // Обычное свойство - обертка, над свойством зависимостей
    public int Age {
        get { return (int)GetValue(AgeProperty); }
        set { SetValue(AgeProperty, value); }
    }

    // Свойства Id и Age должно быть в диапазоне от 0 до 99, после компиляции статический
    // анализатор будет подсвечивать ошибку в разметке XAML если указать неккоректное значение
    private static bool IsValidRange(object value) {
        return ((int)value < 100 && (int)value >= 0) ? true : false;
    }

    // Если начать вводить больше 10 символов в поле Name в разметке,
    // то статический анализатор уже сразу предупреждение выдаст о недопустимом значении
    private static bool IsValidLenght(object value) {
        return ((string)value).Length <= 10 ? true : false;
    }
}
