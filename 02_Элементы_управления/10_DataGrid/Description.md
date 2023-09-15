### Класс DataGrid - *Представляет элемент управления, отображающий данные в настраиваемой сетке.*

*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.datagrid?view=windowsdesktop-7.0*

Элемент управления DataGrid позволяет отображать и изменять данные из различных источников, таких как база данных SQL, запрос LINQ или любой другой привязываемый источник данных. 

<img align="left" width="400" height="330" src="img/List.png" alt="Пример работы данного кода"/>

~~~C#
using System.Windows;

namespace _09_ListView;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }
}

public class EmployeeInfoDataSource {
    public string? FirstName { get; set; }
    public string? LastName  { get; set; }
    public int Number {  get; set; }
}
~~~

~~~XAML
<Window x:Class="_09_ListView.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:_09_ListView"
        xmlns:col="clr-namespace:System.Collections;assembly=mscorlib"
        mc:Ignorable="d"
        Title="MainWindow" Height="360" Width="480">
    <Grid>
        <ListView ItemsSource="{DynamicResource ResourceKey=EmployeeInfoDataSource}">
            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=FirstName}" Header="First Name" Width="100"/>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=LastName}"  Header="Last Name"  Width="100"/>
                    <GridViewColumn DisplayMemberBinding="{Binding Path=Number}"    Header="Number." Width="100"/>
                </GridView>
            </ListView.View>
            <ListView.Resources>
                <col:ArrayList x:Key="EmployeeInfoDataSource">
                    <local:EmployeeInfoDataSource FirstName="Tom" LastName="Anderson" Number="1"/>
                    <local:EmployeeInfoDataSource FirstName="Tim" LastName="Anderson" Number="2"/>
                    <local:EmployeeInfoDataSource FirstName="Ted" LastName="Anderson" Number="3"/>
                    <local:EmployeeInfoDataSource FirstName="Tor" LastName="Anderson" Number="4"/>
                </col:ArrayList>
            </ListView.Resources>
        </ListView>
    </Grid>
</Window>
~~~
<hr>
