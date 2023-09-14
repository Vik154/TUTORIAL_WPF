### Класс ScrollViewer - *Представляет прокручиваемую область, которая может содержать другие видимые элементы.*

*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.scrollviewer?view=windowsdesktop-7.0*

Прокрутка необходима, если нужно поместить большой объем содержимого в ограниченную область. Для обеспечения прокрутки необходимо упаковать соответствующее содержимое в элемент ScrollViewer. Объект ScrollViewer может содержать все, что угодно, но обычно это контейнер компоновки. <br>

<img align="left" width="200" height="190" src="img/Scroll.png" alt="Пример работы данного кода"/>

~~~XAML
<ScrollViewer HorizontalScrollBarVisibility="Auto">
    <StackPanel>
        <TextBlock TextWrapping="Wrap" Margin="10">
            Пример прокрутки
        </TextBlock>
        <Rectangle Fill="LightBlue"  Width="500" Height="500"></Rectangle>
    </StackPanel>
</ScrollViewer>
~~~




Одним из классов, порожденных от ContentControl, является HeaderedContentControl. Это просто контейнер с содержимым (один элемент, хранится в свойстве Content) и заголовком (также один элемент, хранится в свойстве Header). Наличие заголовка отличает HeaderedContentControl от описанных ранее элементов управления содержимым. От класса HeaderedContentControl порождены три класса: GroupBox, Tabltem и Expander.

Класс GroupBox — наиболее простой из трех элементов управления, порожденных от HeaderedContentControl. Он имеет вид прямоугольника с закругленными углами и заголовком. Элементу GroupBox нужен контейнер компоновки (наподобие StackPanel) для размещения содержимого. Он часто используется для группировки небольшого количества взаимосвязанных элементов управления, таких как кнопки переключателя. Однако в классе GroupBox нет никаких встроенных функций, поэтому его можно применять где угодно и как угодно.

<img align="left" width="210" height="210" src="img/Group.png" alt="Пример работы данного кода"/>

~~~XAML
<GroupBox Margin="10" Padding="5" Background="AliceBlue" Header="Список языков">
    <StackPanel>
        <RadioButton Margin="5">C++</RadioButton>
        <RadioButton Margin="5">C#</RadioButton>
        <RadioButton Margin="5">C</RadioButton>
        <RadioButton Margin="5">Python</RadioButton>
        <Button Margin="5" Width="100" HorizontalAlignment="Left" Content="Отправить"/>
    </StackPanel>
</GroupBox>
~~~

Класс Expander (расширитель) - содержит область содержимого, которую пользователь может показать или скрыть, щелкнув на кнопочке со стрелкой. Такие элементы часто встречаются в оперативных подсказках и на веб-страницах, чтобы уместить большой объем содержимого, но не завалить пользователя информацией, которая ему не нужна. Использовать объект Expander очень просто: нужно лишь упаковать в него все сворачиваемое содержимое. Обычно все расширители первоначально свернуты, но это можно изменить в разметке (или в коде), установив для них свойство IsExpanded. <br>
В классе Expander определено свойство IsExpanded и события Expanded/Collapsed. Кроме того, он позволяет задать направление развертывания (Up, Down, Left, Right) с помощью свойства ExpandDirection. Кнопка внутри Expander в действительности представляет собой элемент ToggleButton с измененным стилем.

<img align="left" width="210" height="210" src="img/Group2.png" alt="Пример работы данного кода"/>

~~~XAML
<Expander Header="Список языков" Margin="10">
    <StackPanel>
        <RadioButton Margin="5">C++</RadioButton>
        <RadioButton Margin="5">C#</RadioButton>
        <RadioButton Margin="5">C</RadioButton>
        <RadioButton Margin="5">Python</RadioButton>
        <Button Margin="5" Width="100" HorizontalAlignment="Left" Content="Отправить"/>
    </StackPanel>
</Expander>
~~~

#### *Программное создание GroupBox:*
~~~C#
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _04_GroupBox_and_Expander;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        MakeGroupBox();
    }

    // Программное создание GroupBox
    private void MakeGroupBox() {
        GroupBox groupBox = new GroupBox {
            Header = "Список языков",
            Margin = new Thickness(10),
            Padding = new Thickness(5),
            Background = Brushes.AliceBlue
        };

        StackPanel stackPanel = new StackPanel();
        CheckBox checkBox1 = new CheckBox { Content = "C++",  Margin = new Thickness(5) };
        CheckBox checkBox2 = new CheckBox { Content = "C",    Margin = new Thickness(5) };
        CheckBox checkBox3 = new CheckBox { Content = "C#",   Margin = new Thickness(5) };
        CheckBox checkBox4 = new CheckBox { Content = "Java", Margin = new Thickness(5) };

        stackPanel.Children.Add(checkBox1);
        stackPanel.Children.Add(checkBox2);
        stackPanel.Children.Add(checkBox3);
        stackPanel.Children.Add(checkBox4);

        groupBox.Content = stackPanel;
        this.Content = groupBox;
    }
}
~~~
