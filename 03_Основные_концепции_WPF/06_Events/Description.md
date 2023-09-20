### Концепция маршрутизируемых событий - *представляет собой событийную модель с большими транспортными возможностями.* 

*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/events/routed-events-overview?view=netdesktop-7.0* <br>

Маршрутизируемые события — это события с большими транспортными возможностями: они могут туннелироваться вниз и распространяться пузырьками наверх по дереву элементов и по пути запускать обработчики событий. Маршрутизируемые события позволяют обработать событие в одном элементе (например, в метке), хотя оно возникло в другом (например, в изображении внутри этой метки). Как и в случае свойств зависимости, маршрутизируемые события можно употреблять и традиционным способом — подключив обработчик событий с нужной сигнатурой. <br>

Модель событий WPF очень похожа на модель свойств WPF. Как и свойства зависимости, маршрутизируемые события представляются статическими полями, доступными только для чтения, которые регистрируются в статическом конструкторе и оформляются в виде стандартного определения события .NET. <br>

Пример реализации события Click в стандартном элементе управления ButtonBase и стандартная документация: <br>
> *MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.eventmanager.registerroutedevent?view=windowsdesktop-7.0#system-windows-eventmanager-registerroutedevent(system-string-system-windows-routingstrategy-system-type-system-type)* <br>
*MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.routedevent?view=windowsdesktop-7.0*
~~~C#
public abstract class ButtonBase : ContentControl, ICommandSource {

    public static readonly RoutedEvent ClickEvent =
                EventManager.RegisterRoutedEvent(                  // регистрация маршрутизированного события
                                        "Click"                    // Имя события
                                       ,RoutingStrategy.Bubble     // Стратегия маршрутизации события
                                       ,typeof(RoutedEventHandler) // Тип обработчика событий
                                       ,typeof(ButtonBase));       // Тип класса владельца маршрутизируемого события

    public event RoutedEventHandler Click {
        add { AddHandler(ClickEvent, value); }
        remove { RemoveHandler(ClickEvent, value); }
    }
}
~~~

Свойства зависимости регистрируются посредством метода DependencyProperty.Register(), а для регистрации маршрутизируемых событий предназначен метод EventManager.RegisterRoutedEvent(). При регистрации события нужно указать имя события, стратегию маршрутизации, делегат, определяющий синтаксис обработчика события, и класс, которому принадлежит событие.

Как правило, маршрутизируемые события упаковываются в обычные события .NET, чтобы сделать их доступными для всех языков .NET. Оболочка события добавляет и удаляет зарегистрированные вызывающие объекты с помощью методов AddHandler() и RemoveHandler(), которые определены в базовом классе FrameworkElement и наследуются каждым элементом WPF.

Листинг показывает, что одним из аргументов метода EventManager.RegisterRoutedEvent() является элемент перечисления RoutingStrategy, описывающего стратегию маршрутизации события, которые бывают: <br>
* *Tunnel – событие генерируется в корневом элементе, затем в каждом дочернем элементе, пока не достигает элемента-источника.*
* *Bubble – событие генерируется в элементе источнике, затем в каждом родительском элементе, вплоть до корня дерева элементов.*
* *Direct – событие генерируется только в элементе-источнике.* <br>

Обработчики маршрутизируемых событий принимают аргумент RoutedEventArgs. Этот класс содержит следующие свойства: <br>
*Source* – источник события в логическом дереве элементов; <br>
*Handled* – при установке в true маршрутизация события в дереве прекращается; <br>
*RoutedEvent* – объект, описывающий маршрутизируемое событие. <br>














Например, свойства Height, Width, Content — все это свойства зависимости:
~~~XAML
<!-- Установка трёх свойств зависимости -->
<Button Height="100" Width="100" Content="Кнопка" />
~~~
~~~C#
// Установка трёх свойств зависимости 
Button button = new Button { Width = 100.0, Height = 100.0, Content = "Кнопка" };
~~~
> Свойства зависимости можно добавлять только к объектам зависимости — классам, порожденных от DependencyObject. Большинство ключевых компонентов инфраструктуры WPF косвенно порождены от DependencyObject. Примером такого порождения - являются элементы управления и компоновки. <br>

С учетом всех этих сходств возникает вопрос: зачем нужно было определять в WPF новый термин для такой знакомой концепции? <br>
Причин достаточно много, вот только некоторые из них: <br>
* __Уведомление об изменениях:__ <br>
_Свойства зависимостей имеют встроенный механизм уведомления об изменениях. Зарегистрировав в метаданных свойства, функцию обратного вызова, вы получите уведомление, когда значение свойства изменится. Также при изменении значений свойства зависимостей, автоматически происходит обновление привязок данных и запуск триггеров._
* __Наследование значений, динамическое разрешение значений и уменьшение объема используемой памяти:__ <br>
_Когда идет обращение к свойству зависимостей, используется динамическое разрешение значений свойств зависимостей, это такой механизм извлечения значений из свойств зависимостей. При извлечении значений из свойств зависимостей, система WPF определяет базовое значение, учитывая целый ряд факторов, наиболее высокий приоритет имеет локальное значение. Если локальное значение не задано, установка значения передается вверх по логическому дереву следующему элементу, который может его принять, итак вплоть до значения по умолчанию. Т.е. если вы определите значение атрибута FontSize в открывающем дескрипторе <Window>, то все элементы управления в этом Window будут по умолчанию иметь этот размер шрифта._ <br>

#### Пример стандартной реализации свойства зависимостей Height класса FrameworkElement:
~~~C#
public class FrameworkElement : UIElement, IFrameworkInputElement, IInputElement,
                                ISupportInitialize, IHaveResources, IQueryAmbient {

        // Статическое свойство зависимостей DependencyProperty. По соглашениям по именованию все свойства зависимостей
        // представляют статические публичные поля (public static) с суффиксом Property.
        /// <summary> Height Dependency Property </summary>
        [CommonDependencyProperty]
        public static readonly DependencyProperty HeightProperty =
                    DependencyProperty.Register(                   // происходит регистрация свойства
                                "Height",                          // имя свойства (в данном случае "Height")
                                typeof(double),                    // тип свойства (в данном случае double)
                                _typeofThis,                       // тип, который владеет свойством
                                new FrameworkPropertyMetadata(     // устанавливает дополнительные настройки свойства
                                    Double.NaN,
                                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                                    new PropertyChangedCallback(OnTransformDirty)),
                                new ValidateValueCallback(IsWidthHeightValid));

        // Обычное свойство .NET - в виде обёртки над свойством зависимостей
        /// <summary> Height Property </summary>
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double Height {
            get { return (double) GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        // Пример, как реализовано уведомление об изменениях размера
        /// <summary> SizeChanged event </summary>
        public static readonly RoutedEvent SizeChangedEvent = EventManager.RegisterRoutedEvent(
                                                                        "SizeChanged",
                                                                        RoutingStrategy.Direct,
                                                                        typeof(SizeChangedEventHandler),
                                                                         _typeofThis);
 
        /// <summary> SizeChanged event. It is fired when ActualWidth or ActualHeight (or both) changed. </summary>
        public event SizeChangedEventHandler SizeChanged {
            add {AddHandler(SizeChangedEvent, value, false);}
            remove {RemoveHandler(SizeChangedEvent, value);}
        }
 
    // Остальной код
}
~~~

Свойства зависимостей требуют порядочного дополнительного кода по сравнению с нормальным свойством CLR. Если класс желает определить свойство зависимости, он должен иметь DependencyObject в своей цепочке наследования, поскольку в этом классе определены методы GetValue() и SetValue(), используемые оболочкой CLR. Поскольку FrameworkElement "является" DependencyObject, это требование удовлетворено. <br>

Учитывая, что свойства зависимостей объявлены как статические поля, они обычно создаются (и регистрируются) внутри статического конструктора класса. Объект DependencyProperty создается вызовом статического метода DependencyProperty.Register(). Этот метод многократно переопределен. <br>

___Класс FrameworkPropertyMetadata:___ <br>
> *MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.frameworkpropertymetadata?view=windowsdesktop-7.0* <br>

Объект FrameworkPropertyMetadata, передаваемый в DependencyProperty.Register(), описывает различные детали о том, как среда WPF должна обрабатывать это свойство в отношении уведомлений обратного вызова (если свойство должно извещать других об изменениях своего значения) и различные опции (представленные перечислением FrameworkPropertyMetadataOptions). Значения FrameworkPropertyMetadataOptions управляют тем, что именно затрагивается данным свойством (работает ли оно с привязкой данных, может ли наследоваться, и т.п.). В данном случае аргументы конструктора FrameworkPropertyMetadata описываются следующим образом:

~~~C#
// устанавливает дополнительные настройки свойства
new FrameworkPropertyMetadata(
    Double.NaN,                                       // Значение свойства по умолчанию.
    FrameworkPropertyMetadataOptions.AffectsMeasure,  // Опции метаданных.
    new PropertyChangedCallback(OnTransformDirty))    // Делегат, указывающий на метод, вызываемый при изменении свойства

private static void OnTransformDirty(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      // Callback for MinWidth, MaxWidth, Width, MinHeight, MaxHeight, Height, and RenderTransformOffset
      FrameworkElement fe = (FrameworkElement)d;
      fe.AreTransformsClean = false;
}
~~~

Как только объект DependencyProperty зарегистрирован, остается поместить поле в оболочку обычного свойства CLR. Блоки get и set не просто возвращают или устанавливают значение переменной-члена класса, но делают это непрямо, используя методы GetValue() и SetValue() из базового класса System.Windows.DependencyObject:

~~~C#
public double Height {
    get { return (double)base.GetValue(HeightProperty); }
    set { base.SetValue(HeightProperty, value); }
}
~~~

#### Создание собственных свойств зависимостей:
Создание свойств зависимостей происходит в несколько этапов: <br>
1. Сначала создается объект, который будет представлять свойство. Это экземпляр класса DependencyProperty в виде статического поля.
   ~~~C#
   // Также тут используется соглашение об именах – суффикс Property в имени свойства зависимостей.
   public static readonly DependencyProperty MyProperty;
   // Свойства зависимости можно добавлять только к объектам зависимости — классам, порожденных от DependencyObject.
   ~~~
2. После чего, свойство регистрируется в статическом конструкторе класса используя статический метод - DependencyProperty.Register(), потому что любое свойство зависимостей должно быть зарегистрировано перед использованием. Экземпляр DependencyProperty возвращается статическим методом DependencyProperty.Register() и происходит инициализация свойства.
    ~~~C#
    public MyClass: DependencyObject {
      public static readonly DependencyProperty NameProperty;
    
      static MyClass() {
          NameProperty =
              DependencyProperty.Register(
                  name: "Name"                                 // Имя свойста
                  ,propertyType: typeof(string)                // Тип свойства
                  ,ownerType: typeof(MyClass)                  // Владелец свойства
                  ,typeMetadata: newPropertyMetadata("Empty")  // метаданные содержат -> значение свойства *по умолчанию*
                  ,validateValueCallback: IsNameValid);        // функция обратного вызова ValidateValueCallback
       }

      // Проверка на null
      private static boolIsNameValid(object name) {
          return !string.IsNullOrEmpty(name as string);
       }
    }  
    ~~~
3. После чего, создаётся экземплярная оболочка свойства. Аксессор и мутатор оболочки должны использовать методы класса DependencyObject.GetValue() и SetValue() для чтения и установки значения свойства зависимостей. Дополнительную работу в аксессоре и мутаторе выполнять не рекомендуется, так как некоторые классы WPF могут обращаться к свойству зависимостей, минуя экземплярную оболочку.
    ~~~C#
    public class MyClass: DependencyObject {
        public string Name {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
    } 
    ~~~

<hr>

___Пример создания свойств:___ <br>

~~~C#
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
~~~

~~~XAML
<Window x:Class="_05_DependencyProperty.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_05_DependencyProperty"
        mc:Ignorable="d"
        Title="MainWindow" Height="360" Width="480">
    <Grid>
        <DataGrid x:Name="dataGridPersons" ItemsSource="{DynamicResource DependencyPersons}">
            <DataGrid.Resources>
                <Style TargetType="DataGrid">
                    <Setter Property="RowBackground" Value="AliceBlue"/>
                    <Setter Property="FontSize" Value="18"/>
                </Style>
            </DataGrid.Resources>

            <DataGrid.Items>
                <local:DependencyPerson1 Id="1" Name="Tom" Age="28"/>
                <local:DependencyPerson1 Id="2" Name="Tim" Age="30"/>
                <local:DependencyPerson1 Id="3" Name="Ted" Age="29"/>
            </DataGrid.Items>

            <DataGrid.Columns>
                <DataGridTextColumn Header="ID"   Binding="{Binding Path=Id}"/>
                <DataGridTextColumn Header="Name" Binding="{Binding Path=Name}"/>
                <DataGridTextColumn Header="Age"  Binding="{Binding Path=Age}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
</Window>
~~~

<img src="img/Prop1.png" alt="Пример работы данного кода"/>








