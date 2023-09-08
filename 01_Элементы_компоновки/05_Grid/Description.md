### Grid (Сетка) - *это наиболее мощный контейнер компоновки в WPF. Grid располагает элементы в невидимой сетке строк и колонок. Хотя в отдельную ячейку этой сетки можно поместить более одного элемента (и тогда они перекрываются), обычно имеет смысл помещать в каждую ячейку по одному элементу.*

*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.grid?view=windowsdesktop-7.0*

Контейнер Grid является идеальным инструментом для разбиения окна на меньшие области, которыми можно управлять с помощью других панелей. Фактически Grid настолько удобен, что при добавлении в Visual Studio нового документа XAML для окна автоматически добавляются дескрипторы Grid в качестве контейнера первого уровня, вложенного внутрь корневого элемента Window. (В проектах VisualStudio и ExpressionBlend панель Grid используется по умолчанию.)

Хотя Grid задуман как невидимый элемент, можно установить свойство Grid.ShowGridLines в true и получить наглядное представление о нем. Это средство на самом деле не предназначено для украшения окна. В действительности это средство для облегчения отладки, которое предназначено для того, чтобы наглядно показать, как Grid разделяет пространство на отдельные области. Благодаря ему, появляется возможность точно контролировать то, как Grid выбирает ширину колонок и высоту строк.
Grid и сам может быть другим контейнером компоновки, который организует собственную группу содержащихся в нем элементов управления.

Создание компоновки на основе Grid — двухшаговый процесс. Сначала выбирается необходимое количество колонок и строк. Затем каждому содержащемуся элементу 
назначается соответствующая строка и колонка, тем самым помещая его в правильное место. Колонки и строки создаются путем заполнения объектами коллекции Grid.ColumnDefinitions и Grid.RowDefinitions. 

#### Пример создания Grid
<img align="left" width="500" height="385" src="img/Grid1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
<!-- ShowGridLines="True" - Отображение разделителя-->
    <Grid ShowGridLines="True">
        <!-- Создание 3х строк-->
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        
        <!-- Создание 3х столбцов -->
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
    </Grid>
</Window>
~~~

Для помещения индивидуальных элементов в ячейку используются присоединенные свойства Grid.Row и Grid.Column. Оба эти свойства принимают числовое значение индекса, начинающееся с 0. Существует одно исключение. Если не указать значение для свойства Grid.Row, то оно предполагается равным 0. То же самое касается и свойства Grid.Column. Таким образом, если опущены оба атрибута элемента, он помещается в первую ячейку Grid. 

<img align="left" width="480" height="385" src="img/Grid2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
    <Grid ShowGridLines="True">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

        <Button Grid.Row="0" Grid.Column="0" Content="Кнопка 1" Background="Aqua"/>
        <Button Grid.Row="0" Grid.Column="1" Content="Кнопка 2" Background="Azure"/>
        <Button Grid.Row="1" Grid.Column="0" Content="Кнопка 3" Background="Bisque"/>
        <Button Grid.Row="1" Grid.Column="1" Content="Кнопка 4" Background="Beige"/>
    </Grid>
</Window>
~~~

#### Задание размеров строк и столбцов
В отличие от элементов типа FrameworkElement, свойства Height и Width элементов RowDefinition и ColumnDefinition по умолчанию неравны Auto (или Double.NaN). и, в отличие от всех прочих свойств Height и Width в WPF, они имеют тип System.Windows.GridLength, а не double. Поэтому панель Grid поддерживает три способа задания размера в элементах RowDefinition и ColumnDefinition:
* ___Абсолютный размер___ - числовое значение Height илиWidth означает, что размер задан в независимых от устройства пикселах (как и все прочие свойства Height
и Width в WPF). В отличие от других способов задания размера, абсолютные значения не позволяют строкам и столбцам увеличиваться или сжиматься при изменении размера самой сетки Grid или находящихся внутри нее элементов.
* ___Автоматический выбор размера___ – если Height или Width равно Auto, то дочерним элементам выделяется столько места, сколько необходимо, но не больше (для свойств Height и Width во всех остальных классах WPF это режим по умолчанию). Для строки эта величина равна высоте самого высокого элемента, а для столбца - ширине самого широкого элемента.
* ___Пропорциональное изменение размера___ - (иногда называется размером «звездочка») предусмотрен специальный синтаксис задания свойств Height и Width,
позволяющий распределить имеющееся пространство поровну или в соответствии с заданными пропорциями. Если задано пропорциональное изменение размера, строка и столбец увеличиваются или сжимаются при изменении размера сетки.

<img align="left" width="480" height="385" src="img/Grid3.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
  <Grid ShowGridLines="True">
    <Grid.RowDefinitions>
      <RowDefinition Height="*"/>
      <RowDefinition Height="300"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="500"/>
      <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <Button Grid.Row="0" Grid.Column="0" Content="Кнопка 1" Background="Aqua"/>
    <Button Grid.Row="0" Grid.Column="1" Content="Кнопка 2" Background="Azure"/>
    <Button Grid.Row="1" Grid.Column="0" Content="Кнопка 3" Background="Bisque"/>
    <Button Grid.Row="1" Grid.Column="1" Content="Кнопка 4" Background="Beige"/>
  </Grid>
</Window>
~~~

#### __Пропорциональные размеры__
Звездочка работает следующим образом:
* Если высота строки или ширина столбца равна \*, то соответствующему структурному элементу выделяется все оставшееся место.
* Если размер задан равным \* для нескольких строк или столбцов, то все оставшееся место делится между ними поровну.
* Перед символом \* можно указывать коэффициент (например, 2* или 5.5*), тогда соответствующей строке или столбцу будет выделено пропорционально больше
места, чем остальным строкам или столбцам, в размере которых присутствует символ \*. Столбец шириной 2\* всегда в два раза шире столбца шириной \* (это
означает в точности то же самое, что 1\*) в той же самой сетке. Столбец шириной 5.5\* в два раза шире столбца шириной 2.75* в той же самой сетке.

___Пример задания пропорциональных размеров с помощью \*___

~~~XAML
<Window ...Стандартный код, сгенерированный VS>

    <StackPanel Background="AntiqueWhite">
        
        <Grid Height="100" Margin="10" ShowGridLines="True">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="150"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Button Background="LightCyan"  Content="Width=150"/>
            <Button Background="LightBlue" Grid.Column="1" Content="Width=*"/>
        </Grid>
        
        <Grid Height="100" Margin="10" ShowGridLines="True">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="150"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Button Background="LightCyan" Content="Width=150"/>
            <Button Background="Aqua" Grid.Column="1" Content="Width=*"/>
            <Button Background="Aquamarine" Grid.Column="2" Content="Width=*"/>
            <Button Background="Azure" Grid.Column="3" Content="Width=*"/>
        </Grid>
        
        <Grid Height="100" Margin="10" ShowGridLines="True">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="150"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="2*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Button Background="LightCyan" Content="Width=150"/>
            <Button Background="Bisque" Grid.Column="1" Content="Width=*"/>
            <Button Background="Beige"  Grid.Column="2" Content="Width=2*"/>
            <Button Background="AliceBlue"  Grid.Column="3" Content="Width=*"/>
        </Grid>
        
        <Grid Height="100" Margin="10" ShowGridLines="True">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="150"/>
                <ColumnDefinition Width="2*"/>
                <ColumnDefinition Width="4*"/>
                <ColumnDefinition Width="3*"/>
            </Grid.ColumnDefinitions>
            <Button Background="LightCyan" Content="Width=150"/>
            <Button Background="BurlyWood"  Grid.Column="1" Content="Width=2*"/>
            <Button Background="Cornsilk"  Grid.Column="2" Content="Width=4*"/>
            <Button Background="Azure"  Grid.Column="3" Content="Width=3*"/>
        </Grid>
    </StackPanel>
</Window>
~~~
<img src="img/Grid4.png" alt="Пример работы данного кода"/>














#### Программное создание DockPanel из кода C#
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
