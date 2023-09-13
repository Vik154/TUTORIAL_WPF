### Button - *Класс представляющий обычную кнопку.*

*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.button?view=windowsdesktop-7.0*

Класс Button представляет вездесущую кнопку Windows. Он добавляет всего два доступных для записи свойства: IsCancel и IsDefault. 
* Если свойство IsCancel имеет значение true, то эта кнопка будет работать в окне как кнопка отмены. Если нажать клавишу <Esc>, когда фокус находится в текущем окне, то сработает эта кнопка. 
* Если свойство IsDefault имеет значение true, то эта кнопка считается кнопкой по умолчанию. Ее поведение зависит от текущей позиции в окне. Если указатель мыши находится на элементе управления, отличном от Button (например, TextBox, RadioButton, CheckBox и т.д.), то кнопка по умолчанию будет выделена голубоватым оттенком — почти так, как если бы она находилась в фокусе. При нажатии клавиши <Enter>, сработает эта кнопка. Однако если навести указатель мыши на другой элемент управления Button, то голубоватым оттенком будет выделена текущая кнопка, и при нажатии <Enter> будет приведена в действие именно эта кнопка, а не кнопка по умолчанию. 

#### Пример создания Button
<img align="left" width="200" height="200" src="img/Button1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
<Grid>  
    <StackPanel Width="120" Height="115" 
                VerticalAlignment="Top"
                HorizontalAlignment="Left"
                Background="AliceBlue">
        <Button Content="Кнопка 1" Background="AntiqueWhite" />
        <Button Content="Кнопка 2" Background="Aqua" />
        <Button Content="Кнопка 3" Background="Aquamarine"/>
        <Button Content="Кнопка 4" Background="BlanchedAlmond"/>
    </StackPanel>
</Grid>
</Window>
~~~

<img align="left"  src="img/Button2.png" alt="Пример работы данного кода"/>
#### Программное создание Button из кода C#
~~~C#
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _01_Button;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
        MakeButtons();
    }

    private void MakeButtons() {

        WrapPanel dockPanel = new WrapPanel { Background = Brushes.AliceBlue };

        for (int i = 0; i < 30; i++) {
            dockPanel.Children.Add(new Button {
                Width = new Random().Next(50, 150),
                Height = new Random().Next(25, 75),
                Background = new SolidColorBrush(Color.FromRgb(
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255)
                    )),
                Content = $"Кнопка {i + 1}"
            });
        }
        this.Content = dockPanel;
    }
}
~~~

<img src="img/GridSplitter3.png" alt="Пример работы данного кода"/>
