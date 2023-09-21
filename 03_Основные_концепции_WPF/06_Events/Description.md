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

Подключить обработчики событий можно, как декларативно в разметке xaml, так и программно в коде C#: <br>
~~~XAML
<!-- Обычно имя метода обработчика события имеет вид ИмяЭлемента_ИмяСобытия. -->
<Button x:Name="MyButton" Click="MyButton_Click" />
~~~
~~~C#
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MyButton.Click += MyButton_Click_from_cs;
        // Или так
        MyButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(MyButton_Click_from_cs));
        // Или так
        MyButton.AddHandler(Button.KeyDownEvent, 
                    new RoutedEventHandler(
                        (object s, RoutedEventArgs e) => {
                            MessageBox.Show($"Source: {(s as Button)?.Name}");
                    }));
    }

    // Обработчик, подключаемый в конструкторе
    private void MyButton_Click_from_cs(object sender, RoutedEventArgs e) { /* Логика работы */ }
}
~~~

Если понадобится открепить обработчик события, то это можно сделать только в коде с помощью операции **-=** или UIElement.RemoveHandler(): <br>
~~~C#
MyButton.Click -= MyButton_Click_from_cs;    // Или так
MyButton.RemoveHandler(Button.ClickEvent, new RoutedEventHandler(MyButton_Click_from_cs));
~~~

#### Маршрутизируемые события бывают трех видов:

* ___Прямые (direct) события:___ <br>
*генерируется только в элементе-источнике.*
* ___Пузырьковые (bubbling) события:___ <br>
*генерируется в элементе источнике, затем в каждом родительском элементе, вплоть до корня дерева элементов.*
* ___Туннелируемые (tunneling) события:___ <br>
*генерируется в корневом элементе, затем в каждом дочернем элементе, пока не достигает элемента-источника.*

__класс RoutedEventArgs:__ <br>
*MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.routedeventargs?view=windowsdesktop-7.0* <br>

Все маршрутизируемые события используют класс RoutedEventArgs, который содержит следующие свойства:

**Source** - Получает или задает ссылку на объект, создавший событие (источник события). <br>
**OriginalSource** - Указывает, какой объект первоначально сгенерировал событие (обычно то же самое, что и Source). <br>
**RoutedEvent** - Возвращает или задает объект RoutedEvent для события, сгенерированного вашим обработчиком. <br>
**Handled** - Позволяет остановить процесс распространения события, если это свойство true, событие прекращает продвижение. <br>

___Пример пузырькового распространение события:___ <br>
*Т.к. событие MouseUp пузырьковое, если щелкнуть на каком-либо вложенном элементе, события будут возникать в порядке возрастания от дочернего элемента к родительскому и проходить все уровни, пока не дойдёт до верхнего элемента.*

<img align="center" width="1200" src="img/Event1.png" alt="Пример работы данного кода"/>

~~~C#
using System.Windows;
using System.Windows.Input;

namespace _06_Events;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
    }

    private void Bubble_MouseUp(object sender, MouseButtonEventArgs e) {
        textBlockInfo.Text += new string('*', 50) + $"\nОбъект: {sender} \n" +
            $"Источник: {e.Source} \nНачальный источник: {e.OriginalSource}\n";
    }
}
~~~

~~~XAML
<Window .... VS>
    <Grid ShowGridLines="True">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

        <ScrollViewer Grid.Column="1" VerticalScrollBarVisibility="Visible">
            <TextBlock x:Name="textBlockInfo" TextWrapping="Wrap"
                       Padding="5" Background="AliceBlue"
                       FontSize="14">
            </TextBlock>
        </ScrollViewer>

        <StackPanel Background="AliceBlue" MouseUp="Bubble_MouseUp">
            <Label Margin="30" HorizontalAlignment="Center"
                   BorderBrush="DarkGreen" BorderThickness="10"
                   MouseUp="Bubble_MouseUp">
                <TextBlock Margin="30" Text="Текст блок" FontSize="18"
                           Background="Aqua" HorizontalAlignment="Center"
                           MouseUp="Bubble_MouseUp">
                    <Rectangle Height="100" Width="100" Margin="20"
                               HorizontalAlignment="Center"
                               Fill="Bisque" MouseUp="Bubble_MouseUp">
                    </Rectangle>
                </TextBlock>
            </Label>
        </StackPanel>
    
    </Grid>
</Window>
~~~
