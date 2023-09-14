### TextBlock, TextBox, PasswordBox, RichTextBox, Label - *Представляют текстовые элементы управления.*

__TextBlock__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.textblock?view=windowsdesktop-7.0* <br>
__TextBox__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.textbox?view=windowsdesktop-7.0* <br>
__PasswordBox__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.passwordbox?view=windowsdesktop-7.0* <br>
__RichTextBox__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.richtextbox?view=windowsdesktop-7.0* <br>
__Label__ -  *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.label?view=windowsdesktop-7.0*

__TextBlock__ - Элемент предназначен для вывода текстовой информации, для создания простых надписей.
__TextBox__ - Элемент предназначен для ввода текстовой информации.
__PasswordBox__ - Элемент предназначен для ввода парольной информации.
__RichTextBox__ - Элемент предназначен для вывода текстового содержимого, насыщенного форматированием, графикой.
__Label__ - Классический элемент управления, который может содержать текст. (в свойстве Content может находиться произвольное содержимое - Button, Menu и пр.)


Прокрутка необходима, если нужно поместить большой объем содержимого в ограниченную область. Для обеспечения прокрутки необходимо упаковать соответствующее содержимое в элемент ScrollViewer. Объект ScrollViewer может содержать все, что угодно, но обычно это контейнер компоновки, который может вмещать в себя только один элемент, поэтому все элементы, помещаемые внутрь ScrollViewer необходимо обернуть в еще один контейнер <br>

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

#### Программная прокрутка 
Для программной прокрутки содержимого окна, можно использовать методы класса ScrollViewer: <br>
* LineUp(), LineDown(), LineLeft(), LineRight() - прокрутка вверх, вниз, влево, вправо, (щелчки на кнопках со стрелками на концах вертикальной полосы прокрутки).
* PageUp(), PageDown(), PageLeft() и PageRight() - прокручивают содержимое на один экран вверх или вниз и эквивалентны щелчкам на поверхности полосы прокрутки выше или ниже ползунка.
* ScrollToEnd(), ScrollToHome(), ScrollToRightEnd(), ScrollToLeftEnd() - прокрутка в нижний конец окна, в начало, в правый и левый конец окна.

<img align="left" width="300" height="525" src="img/Scroll1.png" alt="Пример работы данного кода"/>

~~~XAML
<StackPanel VerticalAlignment="Top"
            HorizontalAlignment="Left"
            Margin="5" Width="200" Height="50" 
            Background="AliceBlue"
            Orientation="Horizontal">
    <Button Margin="5" Content="Вверх"  Click="UpClick"></Button>
    <Button Margin="5" Content="Вниз"   Click="DownClick"></Button>
    <Button Margin="5" Content="Влево"  Click="LeftClick"></Button>
    <Button Margin="5" Content="Вправо" Click="RightClick"></Button>
</StackPanel>

<ScrollViewer x:Name="_scroll" Background="AliceBlue"
              Margin="5,60,0,0"
              HorizontalScrollBarVisibility="Visible"
              VerticalScrollBarVisibility="Visible">
    <StackPanel Width="1000" Height="500">
        <CheckBox Margin="5">C++</CheckBox>
        <CheckBox Margin="5">C</CheckBox>
        <CheckBox Margin="5">C#</CheckBox>
        <CheckBox Margin="5">Java</CheckBox>
        <CheckBox Margin="5">Python</CheckBox>
        <CheckBox Margin="5">TS</CheckBox>
        <CheckBox Margin="5">JS</CheckBox>
    </StackPanel>
</ScrollViewer>
~~~
---
~~~C#
using System.Windows;

namespace _05_ScrollViewer; 

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
    }

    private void UpClick(object sender, RoutedEventArgs e) {
        _scroll.LineUp();
    }

    private void DownClick(object sender, RoutedEventArgs e) {
        _scroll.LineDown();
    }

    private void LeftClick(object sender, RoutedEventArgs e) {
        _scroll.LineLeft();
    }

    private void RightClick(object sender, RoutedEventArgs e) {
        _scroll.LineRight();
    }
}
~~~
