### Концепция ресурсов - *представляет собой способ поддержания вместе набора полезных объектов, таких как наиболее часто используемые кисти, стили или шаблоны*


Представляет элемент управления для выбора с раскрывающимся списком, который можно отображать и скрывать, щелкая стрелку в элементе управления.*

*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.combobox?view=windowsdesktop-7.0*

Элемент ComboBox похож на элемент ListBox. Он хранит коллекцию объектов ComboBoxItem, которые создаются явным или неявным образом. Как и ListBoxItem, ComboBoxItem является элементом управления содержимым, который может хранить любой вложенный элемент. <br>
Основным различием классов ComboBox и ListBox является способ их отображения в окне. Элемент ComboBox использует раскрывающийся список, а это значит, что за один раз можно выбрать только один элемент.

<img align="left" width="300" height="290" src="img/Combo.png" alt="Пример работы данного кода"/>

~~~XAML
<StackPanel Background="AliceBlue">
    <ComboBox Text="Студенты" IsEditable="True">
        <ComboBoxItem>Student 1</ComboBoxItem>
        <ComboBoxItem>Student 2</ComboBoxItem>
        <ComboBoxItem>Student 3</ComboBoxItem>
    </ComboBox>

    <ComboBox Text="Язык" IsEditable="True">
        <TextBlock>C++</TextBlock>
        <TextBlock>C#</TextBlock>
        <TextBlock>C</TextBlock>
    </ComboBox>
</StackPanel>
~~~
<hr>

___Программное создание ComboBox:___
~~~C#
using System.Windows;
using System.Windows.Controls;

namespace _08_ComboBox;

public record class Person(string Name, string Company, int ID);

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        MakeComboBox();
    }

    private void MakeComboBox() {
        ComboBox comboBox = new ComboBox();
        StackPanel stackPanel = new StackPanel();

        comboBox.Items.Add(new Person("Tom", "Microsoft", 1));
        comboBox.Items.Add(new Person("Tim", "Yandex", 2));
        comboBox.Items.Add(new Person("Tor", "Google", 3));

        comboBox.IsEditable = true;
        comboBox.Text = "Сотрудники";

        stackPanel.Children.Add(comboBox);

        this.Content = stackPanel;
    }
}
~~~
