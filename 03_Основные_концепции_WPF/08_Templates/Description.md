### Концепция шаблонов - *представляет собой расширенную модель визуализации элементов WPF.* 

*MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/controls/styles-templates-overview?view=netdesktop-7.0* <br>
*MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/controls/how-to-create-apply-template?view=netdesktop-7.0* <br>
*Источник 1: https://metanit.com/sharp/wpf/12.php* <br>
*Источник 2: https://professorweb.ru/my/WPF/Template/level17/17_1.php* <br>
*Источник 3: https://intuit.ru/studies/courses/2322/622/lecture/21231?page=2* <br>
*Источник 4: https://studylib.ru/doc/4263762/windows-presentation-foundation--wpf--%E2%80%93-e-to-tehnologiya-dlya* <br>

Шаблоны – фундаментальная концепция технологии WPF. Шаблоны обеспечивают настраиваемое представление (внешний вид) для элементов управления и произвольных объектов, отображаемых как содержимое элементов. Большинство элементов управления имеют внешний вид и поведение. Например, класс Control содержит встроенный набор правил, определяющий его отрисовку (в виде набора более простых элементов). Этот набор правил называется шаблоном Control’а (control template). Описывается он как блок XAML-разметки и применяется к Control’у через свойство "Template". <br>
Для примера давайте рассмотрим простую кнопку. Предположим, создавая пользовательский Control, вы пожелаете получить больше контроля над эффектами затенения и анимации кнопки. В этом случае первым делом нужно заменить существующий стандартный шаблон кнопки на свой собственный. Для того, чтобы создать шаблон кнопки, вам понадобится нарисовать свой бордюр кнопки, ее фон, а также предусмотреть размещение контента кнопки. На роль бордюра имеется несколько кандидатов, тут все зависит от того, какой корневой элемент вы выберите: <br>
* __Border__ - Данный элемент решает две задачи: может содержать один элемент внутри себя (скажем TextBlock с заголовком кнопки), и отображать окаймляющий бордюр.
* __Grid__ - Расположив несколько элементов в одном месте, вы можете создать кнопку с каемкой. Воспользуйтесь элементом формы (таким как Rectangle или Path) и в той же ячейке разместите TextBlock. Одно из достоинств контейнера Grid в том, что он поддерживает автоматический контроль размера, и вы можете быть уверены, что ваш Control будет всегда иметь размер, соответствующий размеру своего содержимого.
* __Canvas__ - В Canvas элементы могут размещаться строго по указанным координатам. В обычной ситуации это излишне, но может быть полезным, если вам требуется разместить несколько фигур особым образом относительно друг друга, например, при создании кнопки со сложным рисунком. <br>

Рассмотрим кнопку: её внешним видом является область для нажатия, а поведением – событие Click, которое вызывается в ответ на нажатие кнопки. WPF эффективно разделяет внешний вид и поведение, благодаря концепции шаблона элемента управления. Шаблон элемента управления полностью определяет визуальную структуру элемента. Шаблон переопределяем в большинстве случаев это обеспечивает достаточную гибкость и освобождает от необходимости написания пользовательских элементов управления.

***Рассмотрим создание пользовательского шаблона для кнопки:*** <br>
Шаблон элемента управления – это экземпляр класса System.Windows.ControlTemplate. <br>
Основным свойством шаблона является свойство содержимого VisualTree, которое содержит визуальный элемент, определяющий внешний вид шаблона. В элементах управления ссылка на шаблон устанавливается через свойство Template. С учётом вышесказанного первая версия шаблона для кнопки будет описана следующей разметкой:

<img src="img/Templ1.png" align="left" width="350" height="210" alt="пример работы данного кода">

~~~XAML
<Button Content="Кнопка" Width="120" Height="50" Margin="10">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Border BorderBrush="Green" BorderThickness="5"
                    Background="Beige" CornerRadius="3">
            </Border>
        </ControlTemplate>
    </Button.Template>
</Button>
~~~

Самый большой недостаток шаблона заключается в том, что он не отображает содержимое кнопки (свойство Content). Исправим это. У шаблона может быть установлено свойство TargetType. Оно содержит тип элемента управления, являющегося целью шаблона. Если это свойство установлено, при описании VisualTree для ссылки на содержимое элемента управления можно использовать объект ContentPresenter (для элементов управления содержимым) или объект ItemsPresenter (для списков).

<img src="img/Templ2.png" align="left" width="350" height="230" alt="пример работы данного кода">

~~~XAML
<Button Content="Кнопка" Width="120" Height="50" Margin="10">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Border BorderBrush="Green" BorderThickness="5"
                    Background="Beige" CornerRadius="3">
                <ContentPresenter/>
            </Border>
        </ControlTemplate>
    </Button.Template>
</Button>
~~~

Вторая версия шаблона не учитывает отступ, заданный на кнопке при помощи свойства Padding. Чтобы исправить это, используем привязку данных. В шаблонах допустим особый вид привязки – TemplateBinding. Эта привязка извлекает информацию из свойства элемента управления, являющегося целью шаблона.

<img src="img/Templ3.png" align="left" width="350" height="250" alt="пример работы данного кода">

~~~XAML
<Button Content="Кнопка" Width="120" Height="50"
        Margin="10" Padding="35,10">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Border BorderBrush="Green" BorderThickness="5"
                    Background="Beige" CornerRadius="3">
                <ContentPresenter Margin="{TemplateBinding Padding}"/>
            </Border>
        </ControlTemplate>
    </Button.Template>
</Button>
~~~

Связывание в шаблонах похоже на обычное связывание данных (data bindings), но весит гораздо меньше, поскольку предназначено специально для шаблонов и поддерживает только одностороннее связывание данных (другими словами, можно передать информацию от Control’а в шаблон, но не наоборот).

Стало быть, вам придется добавить в ContentPresenter приличное количество элементов, если вы, конечно, хотите получить полноценную поддержку свойств класса Button и иметь возможность задавать такие свойства, как выравнивание, перенос текста, и т.д. <br>
ControlPresenter в составе стандартного шаблона кнопок выглядит примерно так: <br>

~~~XAML
<ContentPresenter
    HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
    Margin="{TemplateBinding Padding}" 
    VerticalAlignment="{TemplateBinding VerticalContentAlignment}" 
    Content="{TemplateBinding Content}" 
    ContentTemplate="{TemplateBinding ContentTemplate}"/>
~~~

Связывание в шаблонах очень важно для свойства Content. Благодаря связыванию содержимое извлекается из Control-а и отображается в ContentPresenter. Зачастую можно не включать связывание для некоторых свойств шаблона, если вы не намерены их использовать.

Замечание: Связывание в шаблонах поддерживает встроенную во все зависимые свойства инфраструктуру мониторинга изменений. Это значит, что если вы изменяете свойство Control-а, шаблон автоматически применяет его новое значение. Это особенно полезно, когда вы используете анимацию, многократно изменяющую значение свойства.

В шаблонах элементов управления часто используются триггеры. Например, для кнопки при помощи триггеров можно реализовать изменение внешнего вида при нажатии или при перемещении указателя мыши:

<img src="img/Templ4.png" align="left" width="320" height="345" alt="пример работы данного кода">

~~~XAML
<Button Content="Кнопка" Width="120" Height="50" Margin="10" Padding="35,10">
  <Button.Template>
    <ControlTemplate TargetType="Button">
      <Border x:Name="_border" BorderBrush="Green" BorderThickness="5"
              Background="Beige" CornerRadius="3">
        <ContentPresenter Margin="{TemplateBinding Padding}"/>
      </Border>

      <ControlTemplate.Triggers>
        <Trigger Property="IsMouseOver" Value="True">
          <Setter TargetName="_border" Property="Background" Value="Blue"/>
        </Trigger>
      </ControlTemplate.Triggers>
    </ControlTemplate>
  </Button.Template>
</Button>
~~~

Обратите внимание – элемент триггера Setter содержит установку свойства TargetName. Как ясно из контекста, TargetName используется, чтобы обратиться к именованному дочернему элементу визуального представления. Этот дочерний элемент должен быть описан до триггера. Заметим, что, как правило, шаблоны элементов управления описываются в ресурсах окна или приложения. Часто шаблон объявляют в стиле элемента управления. Это позволяет создать эффект "шаблона по умолчанию" (в отличие от стиля, шаблон нельзя указать в ресурсах без ключа).

~~~XAML
<Window.Resources>
    <Style TargetType="Button">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button" />
                <!--содержимое шаблона не изменилось-->
            </Setter.Value>
        </Setter>
    </Style>
</Window.Resources>
~~~

___Сочетание шаблонов со стилями:___ <br>

<img src="img/Templ5.png" align="center" width="1200" alt="пример работы данного кода">

~~~XAML
<Window ....... VS>
    <Window.Resources>
        <Style x:Key="default" TargetType="Button">
            <Setter Property="Background" Value="AliceBlue"/>
            <Setter Property="FontSize" Value="16"/>
            <Setter Property="Padding" Value="30,3"/>
            <Setter Property="Margin" Value="10"/>
            <Setter Property="Width" Value="150"/>
            <Setter Property="Height" Value="40"/>

            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border x:Name="_border" 
                                BorderBrush="Black" 
                                BorderThickness="3"
                                CornerRadius="8"
                                Background="{TemplateBinding Background}">
                            <ContentPresenter Margin="{TemplateBinding Padding}"/>
                        </Border>

                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter TargetName="_border" Property="Background" Value="Blue"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            
        </Style>
    </Window.Resources>

    <StackPanel HorizontalAlignment="Left">
        <Button Content="Кнопка 1" Style="{StaticResource default}" />
        <Button Content="Кнопка 2" Style="{StaticResource default}" />
        <Button Content="Кнопка 3" Style="{StaticResource default}" />
    </StackPanel>    
</Window>
~~~

<hr>

#### Добавление шаблона в словарь ресурсов:

~~~XAML
<!-- App.xaml -->
<Application x:Class="_08_Templates.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:_08_Templates"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary1.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>

<!-- Dictionary1 -->
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <ControlTemplate TargetType="Button"  x:Key="Gradient1">
        
        <Border Name="Border" 
                CornerRadius="25" 
                BorderBrush="Aquamarine"  
                BorderThickness="3"
                Background="LightBlue" 
                Height="30" Width="90"
                >
            <ContentControl Margin="5" 
                            HorizontalAlignment="Center" 
                            VerticalAlignment="Center" 
                            Content="Кнопка" />
        </Border>
        
        <ControlTemplate.Triggers>
            
            <!--При наведении мыши-->
            <Trigger Property="IsMouseOver" Value="True">
                <Setter TargetName="Border" Property="Background" Value="Blue"/>
            </Trigger>

            <!--При нажатии-->
            <Trigger Property="IsPressed" Value="True">
                <Setter TargetName="Border" Property="Background" Value="DarkBlue"/>
            </Trigger>
            
            <!--Если кнопка отключена-->
            <Trigger Property="IsEnabled" Value="False">
                <Setter TargetName="Border" Property="TextBlock.Foreground" Value="Black" />
                <Setter TargetName="Border" Property="Background" Value="MistyRose" />
            </Trigger>
            
        </ControlTemplate.Triggers>
    </ControlTemplate>

    <Style TargetType="{x:Type Button}">
        <Setter Property="Control.Template" Value="{StaticResource Gradient1}"/>
    </Style>
</ResourceDictionary>

<!-- MainWindow -->
<Window ... VS>
    <StackPanel HorizontalAlignment="Left">
        <Button Margin="10" Content="Кнопка 3" />
        <Button Margin="10" Content="Кнопка 3" />
    </StackPanel>
</Window>
~~~

~~~C#
using System.Windows;

namespace _08_Templates;

public partial class MainWindow : Window {

    private static ResourceDictionary _resources = new ResourceDictionary();

    public MainWindow() {
        InitializeComponent();

        _resources.Source = new System.Uri("Dictionary1.xaml", System.UriKind.Relative);
        Application.Current.Resources.MergedDictionaries[0] = _resources;
    }
}
~~~
