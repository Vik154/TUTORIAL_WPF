### Концепция зависимых свойств (Dependency Property) - *представляет собой расширение функциональных возможностей стандартных свойств CLR.* 

*Информация MSDN: https://learn.microsoft.com/ru-ru/dotnet/desktop/wpf/properties/dependency-properties-overview?view=netdesktop-7.0* <br>




___Простой пример привязки данных:___ <br>
В данном примере элемент TextBox с именем x:Name="_source" является источником, а TextBox с именем x:Name="_receiver" - приемником привязки. Свойство Text элемента \<TextBox x:Name="_source"\> привязывается к свойству Text элемента \<TextBox x:Name="_receiver"\>. В итоге при осуществлении ввода в текстовое поле синхронно будут происходить изменения в текстовом блоке.

<img align="left" width="270" height="225" src="img/Bind.png" alt="Пример работы данного кода"/>

~~~XAML
<Window ...VS>
    <Grid>
        <StackPanel HorizontalAlignment="Left">
            <TextBox x:Name="_source" Margin="10" Height="50" />
            <TextBox x:Name="_receiver" Margin="10" Height="50"
                     Text="{Binding ElementName=_source, Path=Text}">
            </TextBox>
        </StackPanel>
    </Grid>
</Window>
~~~

