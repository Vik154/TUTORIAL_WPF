### StackPanel - *Размещает элементы в последовательностях строк с переносом. В горизонтальной ориентации WrapPanel располагает элементы в строке слева направо, затем переходит к следующей строке. В вертикальной ориентации WrapPanel располагает элементы сверху вниз, используя дополнительные колонки для дополнения оставшихся элементов*

*Описание класса: [https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.stackpanel?view=windowsdesktop-7.0](https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.wrappanel?view=windowsdesktop-7.0)*

StackPanel не требует задавать присоединенные свойства для получения приемлемого пользовательского интерфейса. На самом деле StackPanel - одна из немногих панелей, в которых вообще не определены собственные присоединенные свойства! В отсутствие присоединенных свойств единственный способ организовать дочерние элементы - воспользоваться свойством панели Orientation (типа System.Windows.Controls.Orientation), которое может принимать значение Horizontal или Vertical. По умолчанию подразумевается ориентация Vertical.

#### Пример создания StackPanel - свойство Orientation = Vertical по умолчанию
<img align="left"  src="img/StackPanel.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
    <Window.Resources>
        <Style TargetType="Button">
            <Setter Property="Height" Value="30"/>
            <Setter Property="Width" Value="150"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="HorizontalAlignment" Value="Left"/>
            <Setter Property="Margin" Value="5,5,0,0"/>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel>
            <TextBlock Text="StackPanel" FontWeight="Bold" Margin="15,5"/>
            <Button Content="Кнопка 1" Background="AliceBlue"/>
            <Button Content="Кнопка 2" Background="AntiqueWhite"/>
            <Button Content="Кнопка 3" Background="Aqua"/>
            <Button Content="Кнопка 4" Background="Aquamarine"/>
            <Button Content="Кнопка 5" Background="Azure"/>
        </StackPanel>
    </Grid>
</Window>
~~~

#### Пример создания StackPanel - свойство Orientation = Horizontal
<img align="left"  src="img/StackPanel2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
    <Window.Resources>
        <Style TargetType="Button" x:Key="style2">
            <Setter Property="Height" Value="200"/>
            <Setter Property="Width" Value="25"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="HorizontalAlignment" Value="Left"/>
            <Setter Property="Margin" Value="5,5,0,0"/>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel Orientation="Horizontal">
            <StackPanel.Resources>
                <Style TargetType="Button" BasedOn="{StaticResource style2}"/>
            </StackPanel.Resources>
            <Button Content="1" Background="AliceBlue"/>
            <Button Content="2" Background="AntiqueWhite"/>
            <Button Content="3" Background="Aqua"/>
            <Button Content="4" Background="Aquamarine"/>
            <Button Content="5" Background="Azure"/>
        </StackPanel>  
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
