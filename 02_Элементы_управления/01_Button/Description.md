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

Лучше всего поместить GridSplitter в отдельную строку или столбец с автоматическим выбором размера. В таком случае он не будет перекрывать содержимое соседних ячеек. Если вы все же решите поместить GridSplitterв одну ячейку с другими элементами, то хотя бы добавляйте его последним (или задавайте свойство ZIndex).
Обычно Grid содержит не более одного GridSplitter. Тме не менее, можно вкладывать один Grid в другой, и при этом каждый из них будет иметь собственный GridSplitter. Это позволяет создавать окна, которые разделены на две области (например, на левую и правую панель), одна из которых (скажем, правая), в свою очередь, также разделена на два раздела (на верхний и нижний с изменяемыми размерами). 

<img align="left" width="350" height="385" src="img/GridSplitter2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...Стандартный код, сгенерированный VS>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
        </Grid.RowDefinitions>
        
        <GridSplitter Grid.Column="1"  Grid.Row="0" 
                      ShowsPreview="False" Width="15"
                      HorizontalAlignment="Center" 
                      VerticalAlignment="Stretch"
                      Background="Gray"/>
        
        <GridSplitter Grid.Row="1" Grid.ColumnSpan="3" Height="15"
                      HorizontalAlignment="Stretch" 
                      VerticalAlignment="Center" 
                      Background="Gray"/>

        <Button Background="Aqua" Grid.Column="0" Grid.Row="0" Content="Левая панель"/>
        <Button Background="LightGreen" Grid.Column="2" Grid.Row="0" Content="Правая панель" />
        <Button Background="Aquamarine" Grid.ColumnSpan="3" Grid.Row="2" Content="Нижняя панель"/>
    </Grid>
</Window>
~~~

#### Программное создание GridSplitter из кода C#
~~~C#
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _06_GridSplitter; 

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MakeGridSplitter();
    }

    // Программное создание GridSplitter
    private void MakeGridSplitter() {

        // Этот код эквивалентен записи Height = "Auto" в XAML
        RowDefinition rowDefinitionAuto = new RowDefinition {
            Height = new GridLength(0, GridUnitType.Auto)
        };

        // Этот код эквивалентен записи Height = "*" в XAML
        RowDefinition rowDefinitionStar1 = new RowDefinition {
            Height = new GridLength(1, GridUnitType.Star)
        };

        // Потому что WPF запрещает владеть одним элементом нескольким контейнерам
        RowDefinition rowDefinitionStar2 = new RowDefinition {
            Height = new GridLength(1, GridUnitType.Star)
        };

        ColumnDefinition columnDefinitionAuto = new ColumnDefinition {
            Width = new GridLength(0, GridUnitType.Auto)
        };

        ColumnDefinition columnDefinitionStar1 = new ColumnDefinition {
            Width = new GridLength(1, GridUnitType.Star)
        };

        ColumnDefinition columnDefinitionStar2 = new ColumnDefinition {
            Width = new GridLength(1, GridUnitType.Star)
        };

        Grid grid = new Grid();
        grid.RowDefinitions.Add(rowDefinitionStar1);
        grid.RowDefinitions.Add(rowDefinitionAuto);
        grid.RowDefinitions.Add(rowDefinitionStar2);
        grid.ColumnDefinitions.Add(columnDefinitionStar1);
        grid.ColumnDefinitions.Add(columnDefinitionAuto);
        grid.ColumnDefinitions.Add(columnDefinitionStar2);

        Button btn1 = new Button { Background = Brushes.AliceBlue, Content = "Кнопка 1" };
        Button btn2 = new Button { Background = Brushes.Aqua, Content = "Кнопка 2" };
        Button btn3 = new Button { Background = Brushes.Azure, Content = "Кнопка 3" };

        grid.Children.Add(btn1);
        grid.Children.Add(btn2);
        grid.Children.Add(btn3);

        Grid.SetColumn(btn1, 0);
        Grid.SetRow(btn1, 0);
        Grid.SetColumn(btn2, 2);
        Grid.SetRow(btn2, 0);

        Grid.SetColumn(btn3, 0);
        Grid.SetRow(btn3, 2);
        Grid.SetColumnSpan(btn3, 3);

        GridSplitter horzGridSplitter = new GridSplitter {
            Background = Brushes.Gray,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Stretch,
            ShowsPreview = false,
            Width = 15
        };

        GridSplitter vertGridSplitter = new GridSplitter {
            Height = 15,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
            Background = Brushes.Gray
        };

        grid.Children.Add(vertGridSplitter);
        grid.Children.Add(horzGridSplitter);

        Grid.SetColumn(horzGridSplitter, 1);
        Grid.SetRow(horzGridSplitter, 0);

        Grid.SetColumn(vertGridSplitter, 0);
        Grid.SetRow(vertGridSplitter, 1);
        Grid.SetColumnSpan(vertGridSplitter, 3);

        this.Content = grid;
    }
}
~~~

<img src="img/GridSplitter3.png" alt="Пример работы данного кода"/>
