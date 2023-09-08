### WrapPanel - *Размещает элементы в последовательностях строк с переносом. В горизонтальной ориентации WrapPanel располагает элементы в строке слева направо, затем переходит к следующей строке. В вертикальной ориентации WrapPanel располагает элементы сверху вниз, используя дополнительные колонки для дополнения оставшихся элементов*

*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.wrappanel?view=windowsdesktop-7.0*

Панель WrapPanel похожа на StackPanel. Но помимо организации дочерних элементов в стопку она создает новые строки или столбцы, когда для одной стопки не хватает места. Это полезно для отображения заранее неизвестного числа элементов, когда компоновка должна отличаться от простого списка.
Как и StackPanel, панель WrapPanel не обладает присоединенными свойствами для управления положением элементов. 
В классе WrapPanel определены три свойства, контролирующие его поведение: 
* Orientation - аналогично одноименному свойству StackPanel с тем отличием, что по умолчанию подразумевается значение Horizontal. В панели с горизонтальной ориентацией элементы располагаются один за другим слева направо, а когда место кончается, переходят на следующую строку. В панели с вертикальной ориентацией элементы располагаются один под другим, а когда место кончается, начинается новый столбец.
* ItemHeight - единая высота для всех дочерних элементов. Каким образом каждый потомок распоряжается этой высотой, зависит от значений его свойств VerticalAlignment, Height и пр. Элементы, ширина которых превышает ItemHeight, отсекаются.
* ItemWidth - единая ширина для всех дочерних элементов. Каким образом каждый потомок распоряжается этой шириной, зависит от значений его свойств HorizontalAlignment, Width и пр. Элементы, высота которых превышает ItemWidth, отсекаются.

По умолчанию свойства ItemHeight и ItemWidth не установлены (точнее, имеют значение Double.NaN). В этом случае панель WrapPanel с вертикальной ориентацией отводит каждому столбцу ширину, равную ширине самого широкого элемента в нем, а панель с горизонтальной ориентацией отводит каждой строке высоту, равную высоте самого высокого элемента в ней. Поэтому по умолчанию ни в строках, ни в столбцах отсечение не производится.

#### Пример создания WrapkPanel - по умолчанию свойство Orientation = Horizontal
<img align="left" Width="350" Height="300" src="img/WrapPanel1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
    <Grid>
        <WrapPanel Background="AliceBlue">
            <Button Height="40" Width="120" Margin="5">Кнопка 1</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 2</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 3</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 4</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 5</Button>
            <Button Height="20" Width="80" Margin="5">Кнопка 6</Button>
            <Button Height="15" Width="30" Margin="5">Кнопка 7</Button>
            <Button Height="25" Width="50" Margin="5">Кнопка 8</Button>
            <Button Height="35" Width="80" Margin="5">Кнопка 9</Button>
            <Button Height="50" Width="90" Margin="5">Кнопка 10</Button>
            <Button Height="25" Width="60" Margin="5">Кнопка 11</Button>
            <Button Margin="5">Кнопка 12</Button>
            <Button Margin="5">Кнопка 13</Button>
            <Button Margin="5">Кнопка 14</Button>
        </WrapPanel>
    </Grid>
</Window>
~~~

#### Свойство Orientation = Vertical
<img align="left" Width="350" src="img/WrapPanel2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
    <Grid>
        <WrapPanel Orientation="Vertical" Background="AliceBlue">
            <Button Height="40" Width="120" Margin="5">Кнопка 1</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 2</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 3</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 4</Button>
            <Button Height="40" Width="120" Margin="5">Кнопка 5</Button>
            <Button Height="20" Width="80" Margin="5">Кнопка 6</Button>
            <Button Height="15" Width="30" Margin="5">Кнопка 7</Button>
            <Button Height="25" Width="50" Margin="5">Кнопка 8</Button>
            <Button Height="35" Width="80" Margin="5">Кнопка 9</Button>
            <Button Height="50" Width="90" Margin="5">Кнопка 10</Button>
            <Button Height="25" Width="60" Margin="5">Кнопка 11</Button>
            <Button Margin="5">Кнопка 12</Button>
            <Button Margin="5">Кнопка 13</Button>
            <Button Margin="5">Кнопка 14</Button>
        </WrapPanel>
    </Grid>
</Window>
~~~

#### Программное создание StackPanel из кода C#
~~~C#
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _02_StackPanel;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();

        StackPanel stackPanel = new StackPanel {            // Создание объекта стек-панель
            VerticalAlignment = VerticalAlignment.Top,      // Задает вертикальное выравнивание
            HorizontalAlignment = HorizontalAlignment.Left, // Задает горизонтальное выравнивание
            Orientation = Orientation.Vertical,             // Размещение элементов внутри стек панели
            Width = 200,                                    // Ширина
            Height = 200,                                   // Высота
            Background = Brushes.AliceBlue                  // Цвет фона
        };

        for (int i = 0; i < 5; ++i) {                       // Добавление 5 кнопок в стек панель
            stackPanel.Children.Add(new Button {            // Создание кнопки
                Content = $"Кнопка {i + 1}",                // Надпись на кнопке
                Height = 30,                                // Высота
                Width = 150,                                // Ширина
                FontWeight = FontWeights.Bold,              // Жирный шрифт
                Margin = new Thickness(5, 5, 0, 0),         // Внешние отступы left,top,r,b

                // Рандомная генерация цвета кнопки
                Background = new SolidColorBrush(Color.FromRgb(
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255)
                    ))
            });
        };
        this.Content = stackPanel;
    }
}
~~~
