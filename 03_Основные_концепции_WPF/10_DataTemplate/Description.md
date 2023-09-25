### Концепция шаблонов данных - *представляет механизм для настройки отображения объектов заданного типа.* 

*MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/data/data-templating-overview?view=netframeworkdesktop-4.8* <br>
*Источник 1: https://metanit.com/sharp/wpf/14.3.php* <br>
*Источник 2: https://professorweb.ru/my/WPF/binding_and_styles_WPF/level20/20_4.php* <br>

**Шаблон данных (data template)** — это фрагмент XAML-разметки, который определяет, как привязанный объект данных должен быть отображен. 
Подобно любому другому блоку XAML-разметки, шаблон может включать любую комбинацию элементов. Он также должен включать одно или более выражений привязки, которые извлекают информацию для отображения. <br>
Шаблоны данных поддерживают два типа элементов управления:
* ___Элементы управления содержимым___ (Button, Label, CheckBox, TabItem, ScrollViewer, Window и др.).
* ___Списочные элементы управления___ (ListBox, ComboBox, Menu, ContextMenu, TabControl, TreeView, ListView, DataGrid). <br>

Элементы управления содержимым поддерживают шаблоны данных через свойство ContentTemplate и отображают то, что помещается в свойство Content. <br>
Списочные элементы управления поддерживают шаблоны данных через свойство ItemTemplate и отображают то, что помещается в свойство ItemsSource. <br>

__Использование DataTemplate:__ <br>
> *https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.datatemplate?view=windowsdesktop-7.0* <br>

<img src="img/Data1.png" align="left" alt="Пример работы данного кода" width="300" height="250">

~~~XAML
<ListBox x:Name="_listStudents">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding Path=Name}" Padding="3"/>
                <TextBlock Text="{Binding Path=SurName}" Padding="3"/>
                <TextBlock Text="{Binding Path=ID}" Padding="3"/>
            </StackPanel>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
~~~

~~~C#
using System.Windows;

namespace _10_DataTemplate;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();

        List<Student> students = new List<Student> {
            new Student { Name = "Иван", SurName = "Иванович", ID = 1},
            new Student { Name = "Иван", SurName = "Иванович", ID = 2},
            new Student { Name = "Иван", SurName = "Иванович", ID = 3}
        };

        _listStudents.ItemsSource = students;
    }
}

public class Student {
    public string Name { get; set; }    = "";
    public string SurName { get; set; } = "";
    public int ID { get; set; }
}
~~~
<hr>

__Отделение и повторное использование шаблонов__ <br>
Подобно стилям, шаблоны часто объявляются как ресурс окна или приложения, который определен в списке, где он используется. Такое отделение часто более ясно, особенно если применяются длинные сложные шаблоны или множество шаблонов к одному и тому же элементу управления. Это также дает возможность повторно использовать шаблоны в более чем одном списочном элементе управления или элементе с содержимым, если нужно представлять данные одинаковым образом в разных местах пользовательского интерфейса.

Все, что потребуется — это определить шаблон данных в коллекции ресурсов и назначить ему ключевое имя. Ниже приведен пример извлечения шаблона, показанного в предыдущем примере:

~~~XAML
<Window .....VS>
    <Window.Resources>
        <DataTemplate x:Key="ListTemplate">
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding Path=Name}" Padding="3"/>
                <TextBlock Text="{Binding Path=SurName}" Padding="3"/>
                <TextBlock Text="{Binding Path=ID}" Padding="3"/>
            </StackPanel>
        </DataTemplate>
    </Window.Resources>

    <Grid>
        <!-- Теперь шаблон данных можно применить с использованием ссылки StaticResource: -->
        <ListBox x:Name="_listStudents" ItemTemplate="{StaticResource ListTemplate}"/>
    </Grid>
</Window>
~~~

Если нужно автоматически повторно использовать тот же шаблон данных в других типах элементов управления, можно воспользоваться другим интересным трюком — установить свойство DataTemplate.DataType, чтобы идентифицировать тип привязанных данных, для которых должен применяться шаблон. Например, предыщущий пример можно было бы изменить, исключив ключ и указав этот шаблон, как предназначенный для привязки объектов Student, независимо от того, где они появляются:

~~~XAML
<Window .....VS>
    <Window.Resources>
        <!--<DataTemplate x:Key="ListTemplate">-->
        <DataTemplate DataType="{x:Type local:Student}">
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding Path=Name}" Padding="3"/>
                <TextBlock Text="{Binding Path=SurName}" Padding="3"/>
                <TextBlock Text="{Binding Path=ID}" Padding="3"/>
            </StackPanel>
        </DataTemplate>
    </Window.Resources>
    
    <Grid>
        <!--<ListBox x:Name="_listStudents" ItemTemplate="{StaticResource ListTemplate}"/>-->
        <ListBox x:Name="_listStudents"/>
    </Grid>
</Window>
~~~

Теперь этот шаблон будет использован с любым списочным элементом или элементом управления содержимым в данном окне, который привязан к объектам Student. Настройку ItemTemplate указывать не нужно.

Шаблоны данных не требуют привязки данных. Другими словами, использовать свойство ItemsSource для заполнения шаблона списка не понадобится. В предыдущих примерах добавлять объекты Student можно было декларативно (в XAML-разметке) или программно (вызывая метод ListBox.Items.Add()). В обоих случаях шаблон данных работает одинаково.


#### Триггеры данных:
> *MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.datatrigger?view=windowsdesktop-7.0* <br>

С помощью триггеров данных (DataTrigger) можно задать дополнительную логику визуализации, которая срабатывает, если свойство привязанного объекта принимает то или иное значение: <br>

~~~XAML
<Window ..... VS>
    <Window.Resources>
        <DataTemplate x:Key="ListTemplate">
            <StackPanel Orientation="Horizontal">
                <TextBlock x:Name="tBlockName" Text="{Binding Path=Name}" Padding="3"/>
                <TextBlock Text="{Binding Path=SurName}" Padding="3"/>
                <TextBlock Text="{Binding Path=ID}" Padding="3"/>
            </StackPanel>

            <DataTemplate.Triggers>
                <!-- при наведении курсора на привязанный элемент, текст станет жирным, как моя бывшая -->
                <DataTrigger Binding="{Binding ElementName=tBlockName, Path=IsMouseOver}" Value="True">
                    <Setter TargetName="tBlockName" Property="FontWeight" Value="Bold"/>
                </DataTrigger>
            </DataTemplate.Triggers>
            
        </DataTemplate>
    </Window.Resources>
    
    <Grid>
        <ListBox x:Name="_listStudents" ItemTemplate="{StaticResource ListTemplate}"/>
    </Grid>
</Window>
~~~

<hr>

#### Иерархические данные HierarchicalDataTemplate и TreeView:

> *MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.hierarchicaldatatemplate?view=netframework-4.8* <br>
> *MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/controls/treeview-overview?view=netframeworkdesktop-4.8* <br>
> *Источник 1: https://professorweb.ru/my/WPF/UI_WPF/level22/22_5.php* <br>
> *Источник 2: https://metanit.com/sharp/wpf/14.8.php* <br>

sdsdsds






