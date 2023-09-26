### INotifyPropertyChanged - *Интерфейс представляющий уведомления об изменении свойств.*

*https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8* <br>
*https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-7.0* <br>
*Источник 1: https://metanit.com/sharp/wpf/11.2.php* <br>

Чтобы гарантировать, что UI обновляется, когда данные изменяются, нужно реализовать соответствующий интерфейс уведомления об изменениях. Если определяют свойства, к которым будут привязаны данные, тогда нужно реализовать интерфейс INotifyPropertyChanged. Если свойства представляют коллекцию, они должны реализовать INotifyCollectionChanged или наследоваться от класса ObservableCollection<T>, который реализует этот интерфейс. Оба этих интерфейса определяют событие, которое генерируется всякий раз, когда базовые данные изменяются. Любые связанные элементы управления будут автоматически обновлены, когда эти события будут сгенерированы.

Когда объект класса изменяет значение свойства, то он через событие PropertyChanged извещает систему об изменении свойства. А система обновляет все привязанные объекты:

~~~C#
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace _12_INotifyPropertyChanged;

public partial class MainWindow : Window {

    private List<Person> persons;

    public MainWindow() {
        InitializeComponent();

        persons = new List<Person> {
            new Person("Ben", "Lee", 33),
            new Person("Bill", "Ramirez", 36),
            new Person("Bobby", "Allen", 38),
            new Person("Brian", "Murphy", 34),
            new Person("Bruce", "Lopez", 35)
        };

        _list.ItemsSource = persons;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
        Person? person = Resources["person"] as Person;
        if (person != null)
            person.FirstName = "Timmy";
    }
}


public class Person : INotifyPropertyChanged {

    private string lastName  = "";
    private string firstName = "";
    private int age;

    public Person() { }

    public Person(string _firstName, string _lastName, int _age) {
        firstName = _firstName;
        lastName = _lastName;
        age = _age;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        if (propertyName != null && PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    public string LastName {
        get { return lastName; }
        set { lastName = value; 
            OnPropertyChanged("LastName"); } 
    }

    public string FirstName {
        get { return firstName; }
        set { firstName = value; OnPropertyChanged("FirstName"); }
    }

    public int Age {
        get { return age; }
        set { age = value; OnPropertyChanged("Age"); }
    }

    public override string ToString() {
        return $"{FirstName}\t{LastName}\t{Age}";
    }
}
~~~

~~~XAML
<Window x:Class="_12_INotifyPropertyChanged.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_12_INotifyPropertyChanged"
        xmlns:sys ="clr-namespace:System;assembly=mscorlib"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        >
    <Window.Resources>
        <local:Person x:Key="person" FirstName="Tom" LastName="Tompson" Age="33"/>
    </Window.Resources>
    
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

        <Button Width="100" Height="30" Margin="5"
                VerticalAlignment="Top"
                HorizontalAlignment="Left"
                Click="Button_Click"
                Content="Изменить значение"
                />
        <StackPanel VerticalAlignment="Top" Margin="0,40,0,0"
                    Orientation="Horizontal"
                    DataContext="{StaticResource person}">
            <TextBlock Margin="5" Text="{Binding FirstName}"/>
            <TextBlock Margin="5" Text="{Binding LastName}"/>
            <TextBlock Margin="5" Text="{Binding Age}"/>
        </StackPanel>
        
        <ListBox Grid.Column="1" x:Name="_list"/>
    </Grid>
</Window>
~~~
