### Концепция ресурсов - *представляет собой способ поддержания вместе набора полезных объектов, таких как кисти, стили или шаблоны.*

*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/systems/xaml-resources-overview?view=netdesktop-7.0*

*Ресурсы можно установить как в коде XAML, так и в коде C# с помощью свойства Resources, но обычно они определяются в XAML разметке. Как только ресурс определен, его можно использовать повсюду в остальной части разметки окна (а в случае, если он представляет собой ресурс приложения, то повсюду в остальной части приложения). Такой подход упрощает разметку, сокращает количество повторяющихся фрагментов кода и позволяет хранить детали, касающиеся пользовательского интерфейса (вроде цветовой схемы приложения), в центральном месте, чтобы в дальнейшем их было проще модифицировать. <br>
Ресурсы объектов также служат основой для многократного использования стилей, что в свою очередь упрощает поддержку кода и если возникнет необходимость изменить ресурс, достаточно это сделать в одном месте, и изменения произойдут глобально в приложении.*

___Коллекция ресурсов:___ <br>
Каждый элемент включает свойство Resources, в котором хранится словарная коллекция ресурсов (представляющая собой экземпляр класса ResourceDictionary). Эта коллекция ресурсов может хранить объект любого типа с индексацией по строке. Хотя каждый элемент имеет свойство Resources (которое определено в классе FrameworkElement), чаще всего ресурсы определяются на уровне окна. Причина в том, что каждый элемент имеет доступ к ресурсам из собственной коллекции ресурсов, а также к ресурсам из коллекции ресурсов всех своих родительских элементов. 

___Определение ресурсов:___
> *Важную роль, в определении ресурсов, играет первый атрибут x:Key. В нем указано имя, под которым должен индексироваться ресурс в словаре ресурсов Window.Resources. Использовать допускается любое имя. Чтобы применить эти ресурсы в свойствайх какого-либо элемента, можно использовать следующий синтаксис: Свойство_Элемента="{StaticResource Имя_Ключа}" - здесь после выражения StaticResource идет ключ применяемого ресурса, а ключевое слово "StaticResource" - означает статический ресурс, а статические ресурсы устанавливаются один раз, при первом создании окна.*

<img align="left" width="250" height="585" src="img/Res1.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ... Стандартный код VS>
    <Window.Resources>
        <!-- Создание ресурсов, для обращения к ним по заданным ключам -->
        <SolidColorBrush x:Key="PanelBackground" Color="AliceBlue"/>
        <SolidColorBrush x:Key="ButtonBackground" Color="Aqua"/>

        <!-- Создание стиля для эллипсов в виде ресурса -->
        <Style x:Key="EllipseStyle" TargetType="Ellipse">
            <Setter Property="Width"  Value="100"/>
            <Setter Property="Height" Value="80"/>
            <Setter Property="Fill"   Value="DarkBlue"/>
            <Setter Property="Margin" Value="10"/>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel Background="{StaticResource PanelBackground}">
            <Ellipse Style="{StaticResource EllipseStyle}"/>
            <Ellipse Style="{StaticResource EllipseStyle}"/>

            <Button Background="{StaticResource ButtonBackground}" Content="Кнопка 1"/>
            <Button Background="{StaticResource ButtonBackground}" Content="Кнопка 2"/>
            <Button Background="Bisque"  Content="Кнопка 3"/>
            <Button Background="{x:Null}" Content="Кнопка 4"/>
            <Button Content="Кнопка 5"/>
        </StackPanel>
    </Grid>
</Window>
~~~

___Статические и динамические ресурсы:___
Отличие сстатических ресурсов от динамических заключается в том, что в случае статического ресурса объект извлекается из коллекции ресурсов только один раз. В зависимости от типа объекта (и способа, которым он используется) любые вносимые в этот объект изменения могут быть замечены сразу же. В случае динамического ресурса, объект отыскивается в коллекции ресурсов при каждом возникновении в нем необходимости. Это означает, что под тем же самым ключом может размещаться и совершенно новый объект, и динамический ресурс будет подхватывать это изменение.

<img align="left" width="250" height="485" src="img/Res2.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ....>
    <Window.Resources>
        <!-- Создание ресурсов, для обращения к ним по заданным ключам -->
        <SolidColorBrush x:Key="ButtonBackground" Color="Aqua"/>
    </Window.Resources>
    
    <Grid>
        <TabControl>
            <TabItem Header="Статичесике и динамические">
                <StackPanel Background="{StaticResource PanelBackground}">
                    <Button Background="{StaticResource ButtonBackground}" 
                            Content="Статический"
                            FontSize="18" FontWeight="Bold"
                            Margin="10" Width="200" />
                    <Button Background="{DynamicResource ButtonBackground}" 
                            Content="Динамический"
                            FontSize="18" FontWeight="Bold"
                            Margin="10,0" Width="200" />
                </StackPanel>
            </TabItem>
        </TabControl>
    </Grid>
</Window>
~~~

