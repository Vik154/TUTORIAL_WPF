### Концепция триггеров - *представляет возможность внесения изменений в свойства стилей автоматически, т.е. изменять значение заданного свойства, как только меняется определенное условие.*

*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.trigger?view=windowsdesktop-7.0* <br>
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/controls/styles-templates-overview?view=netdesktop-7.0* <br>
*Информация MSDN: https://learn.microsoft.com/ru-ru/windows/apps/design/style/xaml-styles*

*Элемент Style можно рассматривать как удобный способ применения набора значений свойств к нескольким элементам. Стиль можно использовать для любого элемента, производного от FrameworkElement или FrameworkContentElement, например Window или Button. <br>
Чаще всего стиль объявляется как ресурс в разделе Resources файла XAML. Так как стили являются ресурсами, для них действуют те же правила определения области, что и для всех других ресурсов. Проще говоря, то, где вы объявляете стиль, влияет на то, где этот стиль может быть применен. Например, если объявить стиль в корневом элементе файла XAML определения приложения, стиль может использоваться в любом месте приложения0. <br>
Т.е. вместо того чтобы заполнять XAML-файл повторяющимся кодом разметки для установки деталей вроде полей, отступов, цветов и шрифтов, можно просто создавать набор охватывающих все эти детали стилей, а затем применять эти стили по мере необходимости, устанавливая единственное свойство.*

___Пример создания стилей:___ <br>
> Здесь определяется единственный стиль, который упаковывает все свойства элемента, подлежащие установке:

<img align="left" width="280" height="465" src="img/Style1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ... Стандартный код VS>
    <Window.Resources>
        <Style x:Key="MyButtonStyle" TargetType="Button">
            <Setter Property="Width"      Value="100"/>
            <Setter Property="Height"     Value="40"/>
            <Setter Property="Margin"     Value="10"/>
            <Setter Property="FontSize"   Value="18"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="Background" Value="AliceBlue"/>
        </Style>
    </Window.Resources>

    <Grid>
        <StackPanel>
            <Button Style="{StaticResource MyButtonStyle}">Кнопка 1</Button>
            <Button Style="{StaticResource MyButtonStyle}">Кнопка 2</Button>
            <Button Style="{StaticResource MyButtonStyle}">Кнопка 3</Button>
            <Button Style="{StaticResource MyButtonStyle}">Кнопка 4</Button>
            <Button Style="{StaticResource MyButtonStyle}">Кнопка 5</Button>
        </StackPanel>
    </Grid>
</Window>
~~~

В данном примере создается один ресурс — объект класса System.Windows.Style. В этом объекте размещается коллекция Setters с объектами Setter, по одному для каждого свойства, которое подлежит установке. В каждом объекте Setter указывается имя свойства (Property), на которое он влияет, и значение (Value), которое он должен применять к этому свойству. Как и все ресурсы, объект стиля имеет ключевое имя (x:Key="Имя"), по которому его можно при необходимости извлекать из коллекции. В данном случае это ключевое имя выглядит как MyButtonStyle. <br>
> *По общепринятому соглашению ключевые имена стилей обычно заканчиваются словом "Style".*

___Применение явного или неявного стиля:___ <br>
Стиль, определенный как ресурс, можно применять к элементам управления двумя способами: <br>
* Неявно, когда указывается только атрибут TargetType для элемента Style;
* Явно, когда указываются атрибуты TargetType и x:Key для элемента Style, а затем в свойстве Style нужного элемента управления задается ссылка на расширение разметки {StaticResource}, которая использует явный ключ. (Как в 1-ом примере)

> *Если стиль содержит атрибут x:Key, то его можно применить к элементу управления только путем задания стиля с ключом в свойстве Style элемента управления. Стиль, не имеющий атрибута x:Key, автоматически применяется к каждому элементу управления целевого типа, если отсутствует явно заданный стиль.*

<img align="left" width="250" height="465" src="img/Style1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...VS>
    <Window.Resources>
        <Style TargetType="Button">
            <Setter Property="Control.Width"      Value="100"/>
            <Setter Property="Control.Height"     Value="40"/>
            <Setter Property="Control.Margin"     Value="10"/>
            <Setter Property="Control.FontSize"   Value="18"/>
            <Setter Property="Control.FontWeight" Value="Bold"/>
            <Setter Property="Control.Background" Value="AliceBlue"/>
        </Style>       
    </Window.Resources>

    <Grid>
        <StackPanel>
            <Button>Кнопка 1</Button>
            <Button>Кнопка 2</Button>
            <Button>Кнопка 3</Button>
            <Button>Кнопка 4</Button>
            <Button>Кнопка 5</Button>
        </StackPanel>
    </Grid>
</Window>
~~~

__Если значение свойства представляет сложный объект, тогда его можно вынести в отдельный элемент:__ <br>
~~~XAML
<Style TargetType="Button">
    <Setter Property="Background">
        <Setter.Value>
            <LinearGradientBrush>
                <LinearGradientBrush.GradientStops>
                     <GradientStop Color="Aquamarine"  Offset="0" />
                     <GradientStop Color="AliceBlue"   Offset="1" />
                </LinearGradientBrush.GradientStops>
            </LinearGradientBrush>
        </Setter.Value>
    </Setter>

    <Setter Property="RenderTransform">
        <Setter.Value>
            <RotateTransform Angle="25"/>
        </Setter.Value>
    </Setter>
</Style>
~~~

___Использование производных стилей, наследование и BasedOn:___ <br>
Для упрощения работы со стилями и оптимизации их многократного использования можно создавать стили, производные от других стилей. Для создания производных стилей служит свойство BasedOn. Производные стили должны применяться к элементу управления того же типа, к которому применяется базовый стиль, или к производному элементу управления. Например, если базовый стиль применяется к элементу ContentControl, то основанные на нем стили могут применяться к элементу ContentControl или к типам, производным от ContentControl, например Button и ScrollViewer. Если в производном стиле не задано значение, оно наследуется от базового стиля. Чтобы изменить значение базового стиля, его следует переопределить в производном стиле.

<img align="left" width="200" height="640" src="img/Style2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...VS>
  <Window.Resources>
    <Style x:Key="BasicStyle" TargetType="ContentControl">
        <Setter Property="Width"  Value="120" />
        <Setter Property="Height" Value="40" />
        <Setter Property="Margin" Value="5" />
    </Style>

    <Style x:Key="ButtonStyle" TargetType="Button" BasedOn="{StaticResource BasicStyle}">
        <Setter Property="Background"  Value="AliceBlue"/>
        <Setter Property="BorderBrush" Value="LightGreen" />
        <Setter Property="Foreground"  Value="DarkBlue" />
        <Setter Property="FontSize"    Value="18" />
    </Style>

    <Style x:Key="CheckBoxStyle" TargetType="CheckBox" BasedOn="{StaticResource BasicStyle}">
        <Setter Property="FontWeight"  Value="Bold" />
        <Setter Property="BorderBrush" Value="Blue" />
        <Setter Property="Foreground"  Value="Green" />
    </Style>
  </Window.Resources>
  <Grid>
    <StackPanel>
        <Button   Style="{StaticResource BasicStyle}">Кнопка 1</Button>
        <Button   Style="{StaticResource ButtonStyle}">Кнопка 2</Button>
        <Button   Style="{StaticResource ButtonStyle}">Кнопка 3</Button>
        <CheckBox Style="{StaticResource BasicStyle}">Кнопка 4</CheckBox>
        <CheckBox Style="{StaticResource CheckBoxStyle}">Кнопка 5</CheckBox>
    </StackPanel>
  </Grid>
</Window>
~~~

#### *Свойства класса Style:*
* __Setters__ - *Коллекция объектов Setter или EventSetter, которые устанавливают значения для свойств и присоединяют обработчики событий автоматически.*
* __Triggers__ - *Коллекция объектов, унаследованных от класса TriggerBase, которые позволяют автоматически изменять настройки стиля. Настройки стиля могут модифицироваться, например, при изменении значения какого-то другого свойства или при поступлении какого-нибудь события*
* __Resources__ - *Коллекция ресурсов, которые должны использоваться со стилями. Например, может понадобиться использовать единственный объект для установки нескольких свойств. В таком случае более эффективно создать объект как ресурс и затем использовать этот ресурс в объекте Setter (вместо создания этого объекта в виде части каждого Setter с применением вложенных дескрипторов).*
* __BasedOn__ - *Свойство, которое позволяет создавать более специализированный стиль, наследующий (и дополнительно переопределяющий) параметры другого стиля.*
* __TargetType__ - *Свойство, которое идентифицирует тип элемента, к которому применяется данный стиль. Это свойство позволяет создавать объекты Setter, влияющие только на определенные элементы, а также объекты Setter, автоматически вступающие в силу для всех элементов подходящего типа* <br>

___Установка свойств:___ <br>
Любой объект Style умещает в себе коллекцию объектов Setter. Каждый объект Setter устанавливает одно свойство в элементе. Единственное ограничение состоит в том, что объект Setter может изменять только свойство зависимости — другие свойства не могут быть модифицированы. <br>
Чтобы идентифицировать свойство, которое должно устанавливаться, необходимо предоставить имя класса и имя свойства. Имя класса, не обязательно должно представлять тот класс, в котором данное свойство определено. Это может быть имя производного класса, который наследует свойство. Например:

~~~XAML
<Style x:Key="MyButtonStyle">
    <Setter Property="Button.FontFamily" Value="Times New Roman" /> 
    <Setter Property="Button.FontSize"   Value="18" /> 
    <Setter Property="Button.FontWeight" Value="Bold" /> 
</Style>

<!-- Если у другого элемента изменяемые свойства существуют, тогда стиль применится и к ним тоже,
     т.к. данные элементы являются наследниками общего класса Control, иначе проигнорируются -->
<Button Style="{StaticResource MyButtonStyle}" .../>
<CheckBox Style="{StaticResource MyButtonStyle}" .../>
<RadioButton Style="{StaticResource MyButtonStyle}" .../>
<Label Style="{StaticResource MyButtonStyle}" .../>
<TextBlock Style="{StaticResource MyButtonStyle}" .../>
~~~

В данном примере смысл состоит в способе обработки средой WPF других классов, которые могут включать те же самые свойства FontFamily, FontSize и FontWeight, но не наследоваться от Button. Например, если применить эту версию стиля MyButtonStyle к элементу управления Label, то связанные со шрифтом свойства окажут влияние на элемент управления Label, потому что класс Label унаследован от Control. 

#### Присоединение обработчиков событий (EventSetter): 
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.eventsetter?view=windowsdesktop-7.0* <br>
Класс EventSetter - представляет метод задания события в стиле. Методы задания событий вызывают заданные обработчики событий в ответ на события.
~~~C#
// Наследование: Object -> SetterBase -> EventSetter
public class EventSetter : System.Windows.SetterBase
~~~
Средства установки свойств являются наиболее общим ингредиентом в любом стиле, но можно также создать коллекцию объектов EventSetter, связывающих события с определенными обработчиками. <br>

<img align="left" width="350" height="500" src="img/Style3.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ....VS>
    <StackPanel Background="AliceBlue">
        <StackPanel.Resources>
            <Style TargetType="{x:Type Button}">
                <EventSetter Event="Click" Handler="buttonSetColor"/>
                <Setter Property="Width" Value="100"/>
                <Setter Property="Height" Value="30"/>
                <Setter Property="Background" Value="Aqua"/>
                <Setter Property="Margin" Value="10"/>
                <Setter Property="HorizontalAlignment" Value="Left"/>
            </Style>
            <Style TargetType="Label">
                <EventSetter Event="MouseMove" Handler="mousePosition"/>
                <Setter Property="FontSize" Value="18"/>
                <Setter Property="FontWeight" Value="Bold"/>
            </Style>
        </StackPanel.Resources>

        <Button x:Name="bt1">Кнопка 1</Button>
        <Button x:Name="bt2">Кнопка 2</Button>
        <Button x:Name="bt3">Кнопка 3</Button>
        <Label x:Name="txt">Курсор</Label>
    </StackPanel>
</Window>
~~~

~~~C#
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _02_Styles;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private void buttonSetColor(object sender, RoutedEventArgs e) {
        if (((Button)sender).Name == "bt1")      bt2.Background = Brushes.Green;
        else if (((Button)sender).Name == "bt2") bt3.Background = Brushes.Red;
        else if (((Button)sender).Name == "bt3") bt1.Background = Brushes.Bisque;
    }

    private void mousePosition(object sender, MouseEventArgs e) {
        txt.Content = $"Позиция X: {e.GetPosition(this).X}; Y: {e.GetPosition(this).Y};";
    }
}
~~~

#### Программное создание стилей:

<img src="img/Style4.png" alt="Пример работы данного кода"/>

~~~C#
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _02_Styles;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MakeStyles();
    }

    // Создание стилей из кода
    private void MakeStyles() {

        StackPanel stackPanel = new StackPanel();
        Button button1 = new Button { Content = "Кнопка 1", Name = "bt1" };
        Button button2 = new Button { Content = "Кнопка 2", Name = "bt2" };
        Button button3 = new Button { Content = "Кнопка 3", Name = "bt3" };

        stackPanel.Children.Add(button1);
        stackPanel.Children.Add(button2);
        stackPanel.Children.Add(button3);

        Style myButtonStyle = new Style { TargetType = typeof(Button) };
        myButtonStyle.Setters.Add(new Setter { Property = Button.WidthProperty,  Value = 100d });
        myButtonStyle.Setters.Add(new Setter { Property = Button.HeightProperty, Value = 30d });
        myButtonStyle.Setters.Add(new Setter { Property = FontSizeProperty, Value = 18d });
        myButtonStyle.Setters.Add(new Setter { Property = FontWeightProperty, Value = FontWeights.Bold });
        myButtonStyle.Setters.Add(new Setter { Property = BackgroundProperty, Value = Brushes.Aquamarine });
        myButtonStyle.Setters.Add(new Setter { Property = HorizontalAlignmentProperty, Value = HorizontalAlignment.Left });
        myButtonStyle.Setters.Add(new Setter { Property = MarginProperty, Value = new Thickness(10) });

        myButtonStyle.Setters.Add(new EventSetter { Event = Button.ClickEvent, Handler = new RoutedEventHandler(buttonSetColorCode) });

        button1.Style = myButtonStyle;
        button2.Style = myButtonStyle;
        button3.Style = myButtonStyle;

        this.Content = stackPanel;
    }

    private void buttonSetColorCode(object sender, RoutedEventArgs e) {
        ((Button)sender).Background = Brushes.Beige;
    }
}
~~~
