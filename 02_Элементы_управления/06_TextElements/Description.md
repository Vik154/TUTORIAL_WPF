### TextBlock, TextBox, PasswordBox, RichTextBox, Label - *Представляют текстовые элементы управления.*

__TextBlock__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.textblock?view=windowsdesktop-7.0* <br>
__TextBox__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.textbox?view=windowsdesktop-7.0* <br>
__PasswordBox__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.passwordbox?view=windowsdesktop-7.0* <br>
__RichTextBox__ - *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.richtextbox?view=windowsdesktop-7.0* <br>
__Label__ -  *Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.label?view=windowsdesktop-7.0*

__TextBlock__ - Элемент предназначен для вывода текстовой информации, для создания простых надписей. <br>
__TextBox__ - Элемент предназначен для ввода текстовой информации. <br>
__PasswordBox__ - Элемент предназначен для ввода парольной информации. <br>
__RichTextBox__ - Элемент предназначен для вывода текстового содержимого, насыщенного форматированием, графикой. <br>
__Label__ - Классический элемент управления, который может содержать текст (или другой элемент).

<img align="left" width="320" height="270" src="img/TextBlock1.png" alt="Пример работы данного кода"/>

~~~XAML
<StackPanel Background="AliceBlue">
    <TextBlock FontSize="20">TextBlock1</TextBlock>
    <TextBlock FontSize="20" Text="TextBlock3" Foreground="DarkBlue"/>
    <TextBlock FontSize="20" Text="TextBlock2"/>
    <TextBlock FontSize="20" Text="TextBloc4" FontWeight="Normal"/>
    <TextBlock.Foreground>
        <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
            <GradientStop Color="Blue" Offset="0.1" />
            <GradientStop Color="Green" Offset="0.75" />
        </LinearGradientBrush>
    </TextBlock.Foreground>
</StackPanel>    
~~~

<img align="left" width="320" height="210" src="img/TextBlock2.png" alt="Пример работы данного кода"/>

~~~XAML
<TabControl>
  <TabItem Header="TextBox" FontWeight="Bold">
    <StackPanel Background="AliceBlue">
        <TextBox Text="Пример поля ввода TextBox"/>
        <TextBox Text="Поле ввода TextBox" Height="50" TextWrapping="Wrap"/>
        <TextBox Text="TextBox" Background="Aqua"/>
    </StackPanel>
  </TabItem>
</TabControl>
~~~

<img align="left" width="320" height="170" src="img/TextBlock3.png" alt="Пример работы данного кода"/>

~~~XAML
<TabItem Header="Password" FontWeight="Bold">
    <StackPanel Background="AliceBlue">
        <PasswordBox PasswordChar="*" Height="30" FontSize="20"/>
        <PasswordBox PasswordChar="+" Height="30" FontSize="20"/>
        <PasswordBox PasswordChar="P" Height="30" FontSize="20"/>
    </StackPanel>
</TabItem>
~~~

<img align="left" width="320" height="250" src="img/TextBlock4.png" alt="Пример работы данного кода"/>

~~~XAML
<TabItem Header="RichTextBox" FontWeight="Bold">
    <StackPanel Background="AliceBlue">
        <RichTextBox>
            <FlowDocument>
                <Paragraph>
                    Контент             
                </Paragraph>
            </FlowDocument>
        </RichTextBox>
    </StackPanel>
</TabItem>
~~~

<img align="left" width="320" height="210" src="img/TextBlock5.png" alt="Пример работы данного кода"/>

~~~XAML
<TabControl>
  <TabItem Header="Label" FontWeight="Bold">
    <StackPanel Background="AliceBlue">
        <Label Content="LABEL 1"/>
        <Label Content="LABEL 2" Background="Aqua"/>
        <Label Content="LABEL 3" Foreground="DarkGreen"/>
    </StackPanel>
  </TabItem>
<TabControl>
~~~


#### Элемент TextBlock: 
У элемента TextBlock есть ряд простых свойств, модифицирующих его внешний вид, например FontFamyly, FontSize, FontStyle, FontWeight и FontStretch. Но главный сорприз TextBlock заключается в том, что его свойством содержимого является не Text, а коллекция объектов Inlines. Хотя показанная ниже разметка дает тот же самый результат, что и установка свойства Text, в действительности мы устанавливаем другое свойство:
~~~XAML
<!-- Здесь устанавливается свойство TextBlock.Inlines: -->
<TextBlock>Текст текст ТеКсТ</TextBlock>
~~~
Конвертер типа создает иллюзию, будто значением является простая строка, хотя на самом деле это коллекция, состоящая из одного элемента Run. Поэтому следующая XAML-разметка в точности эквивалентна предыдущей:
~~~XAML
<TextBlock>
    <Run Text="Текст текст ТеКсТ"/>
</TextBlock>
~~~
и, в свою очередь, эквивалентна такой (поскольку Text — это свойство содержимого в классе Run):
~~~XAML
<TextBlock>
    <Run>Текст текст ТеКсТ</Run>
</TextBlock>
~~~
Объект Run - это просто фрагмент текста с одним и тем же форматированием. Явное использование одного элемента Run не дает никаких преимуществ, но, когда в одном блоке TextBlock встречается несколько элементов Run, картина становится интереснее. Например, показанный выше TextBlock можно было бы записать и так:
~~~XAML
<TextBlock>
    <Run>Т</Run>
    <Run>Е</Run>
    <Run>К</Run>
    <Run>С</Run>
    <Run>Т</Run>
</TextBlock>
~~~
В классе Run имеется несколько свойств форматирования, позволяющих переопределить соответствующие свойства, установленные в родительском элементе TextBlock, а именно: FontFamily, FontSize, FontStretch, FontStyle, FontWeight, Foreground и TextDecorations. Например:
~~~XAML
<TextBlock>
    <Run FontFamily="Georgia"       FontStyle="Italic"  Foreground="Red"> курсив </Run>
    <Run FontFamily="Comic Sans MS" FontSize="30"       Foreground="Blue"> синий </Run>
    <Run FontFamily="Arial Black"   FontSize="100"      Foreground="Orange"> как </Run>
    <Run FontFamily="Courier New"   FontWeight="Bold"   Foreground="Green"> мой </Run>
    <Run FontFamily="Verdana"       TextDecorations="Underline"> сосед </Run>
</TextBlock>
~~~

___Явно и неявно заданные фрагменты Run Следующий элемент TextBlock:___
~~~XAML
<TextBlock>ТЕКСТ</TextBlock>
<!-- эквивалентен такому: -->
<TextBlock>
    <Run>ТЕКСТ</Run>
</TextBlock>

<!-- Например, такое использование элемента LineBreak (еще одной разновидности Inline) допустимое! -->
<TextBlock>
    ТЕКСТ И
    <LineBreak/>
    СНОВА ТЕКСТ
</TextBlock>

<!-- а такое - нет: -->
<TextBlock>
    <Run>
    ТЕКСТ И
        <LineBreak/>
    СНОВА ТЕКСТ
    </Run>
</TextBlock>
~~~
> *Последний вариант недопустим, потому что свойством содержимого класса (Text) является простая строка, а включить элемент LineBreak внутрь строки нельзя. Однако конвертер типа преобразует свойство содержимого класса TextBlock (Inlines) в один или несколько объектов Run, корректно обрабатывая объекты LineBreak. В результате следующая XAML-разметка, оказывается эквивалентной блоку TextBlock, содержащему два объекта Run, по одному с каждой стороны LineBreak:*
~~~XAML
<TextBlock>
    ТЕКСТ И
    <LineBreak/>
    СНОВА ТЕКСТ
</TextBlock>

<TextBlock>
    <Run>ТЕКСТ И</Run>
    <LineBreak/>
    <Run>СНОВА ТЕКСТ</Run>
</TextBlock>
~~~

#### Элемент TextBox: 
Элемент управления TextBox, позволяет вводить одну или несколько строк текста. В отличие от большинства других элементов управления в WPF, содержимое TextBox хранится не в виде объекта типа System.Object, а в строковом свойстве Text. В него встроена весьма развитая функциональность, привязки для команд Cut, Copy, Paste, Undo и Redo и даже проверка правописания! В классе TextBox определено несколько методов и свойств для выбора различных частей текста (выделенного фрагмента, по номеру строку и т. д.), а также методы для поиска физической точки в тексте по номеру строки и символа и наоборот. Определены также события TextChanged и SelectionChanged. Если на размер элемента TextBox не налагает ограничений окружение (и он не задан явно), то элемент растет по мере добавления в него текста. Если же ширина TextBox ограничена, то можно установить режим переноса строк, присвоив свойству TextWrapping значение Wrap или WrapWithOverflow. В режиме Wrap содержимое ни при каких условиях не может выйти за пределы области, занятой элементом, даже если придется разорвать строку в середине слова. В режиме WrapWithOveгflow строка разрывается, только если есть такая возможность, так что длинные слова могут выйти за границы области. (В классе TextBlock также есть свойство TextWrapping.) <br>
> Чтобы включить проверку правописания в TextBox (или RichTextBox), необходимо присвоить присоединенному свойству SpellCheck.IsEnabled значение true.
> Также TextBox содержит методы, которые позволяют программно перемещаться по текстовому содержимому небольшими или крупными шагами. Это LineUp(), LineDown(), PageUp(), PageDown(), ScrollToHome(), ScrollToEnd() и ScrollToLine().

Иногда текстовые поля создаются исключительно для отображения текста. В этом случае задайте свойство IsReadonly равным true, чтобы запретить редактирование текста. Это лучше блокирования текстового поля путем присваивания свойству IsEnabled значения false, т.к. заблокированное текстовое окно выводит серый текст (его труднее читать), не поддерживает выделение текста (или копирование в буфер обмена) и его прокрутку.
<hr>

___Автоматическое расширение контейнера для размещения нескольких строк текста:___
> Если атрибуту TextWrapping задать значение Wrap, введенный текст при достижении границы элемента управления TextBox будет переноситься на новую строку, а элемент TextBox при необходимости будет автоматически расширяться, предоставляя пространство для новой строки. <br>
Если атрибуту AcceptsReturn задать значение true, при нажатии клавиши ВВОД будет вставляться новая строка, а элемент TextBox также при необходимости будет автоматически расширяться, предоставляя пространство для новой строки. <br>
Атрибут VerticalScrollBarVisibility добавляет полосу прокрутки к элементу TextBox, которая позволяет просматривать содержимое TextBox, если элемент TextBox расширяется за пределы фрейма или окна, в котором он находится. <br>

~~~XAML
<TextBox Name="tbMultiLine"
         TextWrapping="Wrap"
         AcceptsReturn="True"
         VerticalScrollBarVisibility="Visible"
         >
         Это текстовое поле допускает ввести несколько строк текста. При нажатии клавиши Enter
         или когда набранный текст достигает края текстового поля, автоматически вставляется новая строка.
</TextBox>
~~~

#### Элемент RichTextBox:
Элемент RichTextBox предоставляет больше возможностей, чем ТехtВох, поскольку может содержать форматированный текст (и допускает наличие в тексте произвольных объектов). У RichTextBox и TextBox общий базовый класс (TextBoxBase), поэтому многие возможности, описанные выше для TextBox, применимы и к RichTextBox. Но некоторые средства TextBox реализованы в RichTextBox более полно. Кроме того, содержимое RichTextBox хранится в свойстве Document типа FlowDocument, а не в простом строковом свойстве Text. Содержимое может даже включать объекты типа UIElement, с которыми можно взаимодействовать и которые генерируют события, если свойство IsDocumentEnabled элемента RichTextBox имеет значение true.

#### Элемент PasswordBox:
Элемент PasswordBox - это упрощенный вариант TextBox, предназначенный для ввода пароля. Вместо вводимых символов в нем отображаются кружочки. Если вам не нравятся кружочки, можете выбрать другой символ с помощью свойства PasswordChar. (По умолчанию предполагается звездочка, которая отображается специальным шрифтом и выглядит, как кружочек.) Текст элемента PasswordBox хранится в строковом свойстве Password. В действительности для более надежной защиты применяется специальный класс System.Security.SecureString. Содержимое объекта типа SecureString шифруется и намеренно стирается, тогда как объекты System.String не шифруются и могут оставаться в куче неопределенно долгое время, пока не будут убраны сборщиком мусора. <br>
Класс PasswordBox не наследует TextBoxBase, как два предыдущих элемента управления, поэтому не поддерживает ни команды Cut, Copy, Undo и Redo (хотя поддерживает команду Paste), ни проверку правописания. <br>
При изменении пароля генерируется событие TextBoxPasswordChanged. Его об-работчик имеет тип RoutedEventHandler, то есть вместе с событием не передается информация о старом и новом паролях. Если нужно узнать текущий пароль, можно просто опросить внутри обработчика свойство Password.



