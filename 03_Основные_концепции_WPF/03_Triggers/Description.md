### Концепция триггеров - *представляет возможность внесения изменений в свойства стилей автоматически, т.е. изменять значение заданного свойства, как только меняется определенное условие.*

*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.trigger?view=windowsdesktop-7.0* <br>
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/controls/styles-templates-overview?view=netdesktop-7.0*

*С помощью ***триггеров*** можно обеспечить реакцию на изменение значения свойства и соответствующим образом автоматически подстроить стиль. Триггеры связываются со стилями через коллекцию Style.Triggers. Каждый стиль может иметь любое количество триггеров, а каждый триггер является экземпляром класса, унаследованного от System.Windows.TriggerBase. Триггеры бывают разных видов:* <br>

* __Trigger__ - Это простейшая форма триггера. Он следит за изменением в свойстве зависимости и затем использует средство установки для изменения стиля.
* __MultiTrigger__ - Похож на Trigger, но поддерживает проверку множества условий. Этот триггер вступает в действие, только если удовлетворены все заданные условия.
* __DataTrigger__ - Этот триггер работает с привязкой данных. Он похож на Trigger, но следит за изменением в любых связанных данных.
* __MultiDataTrigger__ - Этот триггер объединяет множество триггеров данных.
* __EventTrigger__ - Это наиболее сложный триггер. Он применяет анимацию, когда возникает соответствующее событие.

__Простой триггер (Trigger):__
Простой триггер может быть присоединен к любому свойству зависимости и задается с помощью объекта Trigger. Он отслеживает значения свойств и в случае их изменения с помощью объекта Setter устанавливают значение других свойств. Например, реагируя на изменения в свойствах IsFocused, IsMouseOver и IsPressed класса Control, можно создать эффекты наведения курсора мыши и получения фокуса.

<img align="left" width="250" height="580" src="img/Trig1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ... VS>
    <Window.Resources>
        <Style x:Key="BaseButtonStyle" TargetType="Button">
            <Setter Property="Width"  Value="100"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="Background" Value="AliceBlue"/>
            <Setter Property="Margin" Value="10"/>

            <Style.Triggers>
                <Trigger Property="IsFocused" Value="True">
                    <Trigger.Setters>
                        <Setter Property="Background" Value="Aquamarine"/>
                        <Setter Property="FontSize" Value="18"/>
                        <Setter Property="FontWeight" Value="Bold"/>
                    </Trigger.Setters>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel HorizontalAlignment="Left">
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 1</Button>
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 2</Button>
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 3</Button>
        </StackPanel>
    </Grid>
</Window>
~~~
В данном примере показан простой триггер свойств, который ожидает получения фокуса на кнопке и устанавливает для нее фон заданного в сеттере триггера цвета. Здесь объект Trigger использует свойство Property, равное "IsFocused" и Value, равное "True". Свойство Property указывает на отслеживаемое свойство, а свойство Value указывает на значение, по достижении которого триггер начнет действовать. Например, в данном случае триггер отслеживает свойство IsFocused (т.е. получение фокуса элементом) - если оно будет равно true, тогда сработает триггер. Триггеры полезны тем, что для отмены их действия не требуется писать никакой логики. Как только триггер перестает быть действительным, элементу сразу же возвращается его обычный внешний вид. В приведенном примере это означает, что как только пользователь уберет с кнопки фокус, нажав клавишу <ТаЬ>, ее фон приобретет обычный цвет. 
<hr>

Допускается создавать множество триггеров, которые могут применяться к одному и тому же элементу одновременно. В случае если в этих триггерах устанавливаются разные свойства, никакой неоднозначности не возникнет. Если же в нескольких триггерах изменяется одно и то же свойство, предпочтение отдается триггеру, находящемуся последним в списке. Например, рассмотрим следующие триггеры, которые подстраивают элемент управления в зависимости от того, находится ли на нем фокус, наводится ли на него курсор мыши и выполняется ли на нем щелчок. <br>
В этом примере при выполнении щелчка на кнопке установить цвет переднего плана попытаются одновременно два триггера. Победит в этом случае триггер, который отвечает за свойство Button.IsPressed, поскольку он идет последним в списке. То, какой из триггеров сработает первым, роли не играет — например, WPF безразлично, что кнопка получает фокус перед выполнением на ней щелчка. Роль играет только порядок, в котором триггеры перечислены в коде разметки. 

<img align="left" width="220" height="665" src="img/Trig2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...VS>
    <Window.Resources>
        <Style x:Key="BaseButtonStyle" TargetType="Button">
            <Setter Property="Width"  Value="100"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="Background" Value="AliceBlue"/>
            <Setter Property="Margin" Value="10"/>

            <Style.Triggers>
                <Trigger Property="IsFocused" Value="True">
                    <Setter Property="Background" Value="Bisque"/>
                </Trigger>

                <Trigger Property="IsMouseOver"  Value="True">
                    <Setter Property="FontWeight" Value="Bold"/>
                </Trigger>

                <Trigger Property="IsPressed" Value="True">
                    <Setter Property="FontSize" Value="20"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel HorizontalAlignment="Left">
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 1</Button>
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 2</Button>
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 3</Button>
        </StackPanel>
    </Grid>
</Window>
~~~

#### MultiTrigger:
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.multitrigger?view=windowsdesktop-7.0* <br>

<img align="right" width="180" height="150" src="img/Trig3.png" alt="Пример работы данного кода"/>

Представляет триггер, который применяет значения свойств или выполняет действия, если выполняется набор условий. Используется когда необходимо отслеживать изменения сразу нескольких свойств одновременно. MultiTrigger содержит коллекцию элементов Condition, которая позволяет определять цепочки комбинаций свойств и значений.
> Здесь порядок, в котором объявляются условия, значения не имеет, поскольку для изменения фона требуется только то, чтобы они все возвращали true. <br>


~~~XAML
<Window ... VS>
    <Window.Resources>
        <Style x:Key="BaseButtonStyle" TargetType="Button">
            <Style.Setters>
                <Setter Property="Width"      Value="100"/>
                <Setter Property="Height"     Value="30"/>
                <Setter Property="Background" Value="Aqua"/>
                <Setter Property="Margin"     Value="10"/>
            </Style.Setters>

            <Style.Triggers>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property="IsFocused" Value="True"/>
                        <Condition Property="IsPressed" Value="True"/>
                    </MultiTrigger.Conditions>

                    <MultiTrigger.Setters>
                        <Setter Property="Foreground" Value="Red"/>
                        <Setter Property="FontSize" Value="18"/>
                    </MultiTrigger.Setters>
                </MultiTrigger>   
            </Style.Triggers>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel HorizontalAlignment="Left">
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 1</Button>
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 2</Button>
            <Button Style="{StaticResource BaseButtonStyle}">Кнопка 3</Button>
        </StackPanel>
    </Grid>
</Window>
~~~

#### Триггер события (EventTrigger):
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.eventtrigger?view=windowsdesktop-7.0* <br>

Представляет триггер, который применяет набор действий в ответ на событие. Если обычный триггер ожидает изменения свойства, то триггер события (EventTrigger) ожидает возникновения конкретного события и в основном его используются для запуска анимации в ответ на вызываемое событие.<br>
Ниже показан пример, в котором триггер событий реагирует на два события "MouseEnter" и "MouseLeave". Т.е. при наведении курсора на элемент TextBlock, выполняет анимацию свойства FontSize, увеличивая размер шрифта до 28 единиц за 0.3 секунды, а при убирании курсора с элемента TextBlock, плавно уменьшается шрифт до размера 18 единиц за 0.8 секунды.

~~~XAML
<Window ...VS>
    <Grid>
        <TextBlock Text="Hello world!"
                   FontSize="18" 
                   HorizontalAlignment="Center" 
                   VerticalAlignment="Center">
            
            <TextBlock.Style>
                
                <Style TargetType="TextBlock">
                    <Style.Triggers>
                        
                        <EventTrigger RoutedEvent="MouseEnter">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Duration="0:0:0.300" 
                                                         Storyboard.TargetProperty="FontSize" 
                                                         To="28" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>
                        
                        <EventTrigger RoutedEvent="MouseLeave">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Duration="0:0:0.800" 
                                                         Storyboard.TargetProperty="FontSize"
                                                         To="18" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger.Actions>
                        </EventTrigger>
                    
                    </Style.Triggers>
                </Style>
            
            </TextBlock.Style>
        </TextBlock>
    
    </Grid>
</Window>
~~~

#### Триггеры данных (DataTrigger):
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.datatrigger?view=windowsdesktop-7.0* <br>

DataTrigger отслеживает изменение свойств, которые необязательно должны представлять свойства зависимостей. Для соединения с отслеживаемыми свойствами триггеры данных используют выражения привязки. В этом примере есть CheckBox и TextBlock, используя DataTrigger и механизм привязки данных, происходит привязка к свойству IsChecked объекта CheckBox и когда изменяются данные в CheckBox (ставится флажок), изменяются данные и в свойствах элемента TextBlock, а при снятие флажка, свойства TextBlock возвращаются в заданные по умолчанию значения.

<img align="left" width="205" height="520" src="img/Trig4.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...VS>
<Grid>
  <StackPanel HorizontalAlignment="Left">
    <CheckBox Margin="10" Name="cbSample" Content="Используете WPF?" />
    <TextBlock Margin="10" FontSize="48">
        
      <TextBlock.Style>
        <Style TargetType="TextBlock">
          <Setter Property="Text" Value="Нет" />
          <Setter Property="Foreground" Value="Red" />
                
          <Style.Triggers>
            <DataTrigger Binding="{Binding ElementName=cbSample, Path=IsChecked}" Value="True">
              <Setter Property="Text" Value="Да!" />
              <Setter Property="Foreground" Value="Green" />
            </DataTrigger>
          </Style.Triggers>
            
        </Style>
      </TextBlock.Style>
    
    </TextBlock>
  </StackPanel>
</Grid>
</Window>
~~~

#### Триггеры множественных данных (MultiDataTrigger):
*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.multidatatrigger?view=windowsdesktop-7.0* <br>

Как и обычный DataTrigger, MultiDataTrigger использует привязку данных для мониторинга свойства. Различие в том, что данный триггер может использоваться для отслеживания изменений сразу во множестве свойств.

<img align="left" width="190" height="450" src="img/Trig5.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...VS>
<StackPanel HorizontalAlignment="Left">
  <CheckBox Margin="5" Name="checkYes"  Content="Используете WPF?" />
  <CheckBox Margin="5" Name="checkSure" Content="А сейчас?" />
  <TextBlock Margin="10" FontSize="48">

    <TextBlock.Style>
      <Style TargetType="TextBlock">
        <Setter Property="Text" Value="Нет" />
        <Setter Property="Foreground" Value="Red" />
             
        <Style.Triggers>
          <MultiDataTrigger>
            <MultiDataTrigger.Conditions>
              <Condition Binding="{Binding ElementName=checkYes, Path=IsChecked}" Value="True"/>
              <Condition Binding="{Binding ElementName=checkSure, Path=IsChecked}" Value="True"/>
            </MultiDataTrigger.Conditions>

            <Setter Property="Text" Value="Да" />
            <Setter Property="Foreground" Value="Green" />
          </MultiDataTrigger>
        </Style.Triggers>
      </Style>
    </TextBlock.Style>

  </TextBlock>
</StackPanel>
</Window>
~~~




