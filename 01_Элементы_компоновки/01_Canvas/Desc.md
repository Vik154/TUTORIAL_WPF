### Canvas (Холст) - *Определяет область, внутри которой можно явным образом разместить дочерние элементы с помощью координат, координаты задаются в независимых от устройства пикселах.*
*Описание класса: https://learn.microsoft.com/ru-ru/dotnet/api/system.windows.controls.canvas?view=windowsdesktop-7.0*

Позволяет размещать элементы, используя точные координаты, что, вообще говоря, является плохим выбором при проектировании развитых управляемых данными форм и стандартных диалоговых окон, но ценным инструментом, когда требуется построить нечто другое (вроде поверхности рисования для инструмента построения диаграмм). Canvas также является наиболее легковесным из контейнеров компоновки. Это объясняется тем, что он не включает в себя никакой сложной логики компоновки, согласовывающей размерные предпочтения своих дочерних элементов. Вместо этого он просто располагает их в указанных позициях с точными размерами, которые нужны. Для позиционирования элемента в контейнере Canvas устанавливаются присоединенные свойства Canvas.Left и Canvas.Top. Свойство Canvas.Left задает количество единиц измерения между левой гранью элемента и левой границей Canvas. Свойство Canvas.Top устанавливает количество единиц измерения между вершиной элемента и левой границей Canvas. Как всегда, эти значения выражаются в независимых от устройства единицах измерения, которые соответствуют обычным пикселям, когда системная установка DPI составляет 96 dpi. 

~~~ XAML
<!--Пример работы с Canvas-->
<Window x:Class       ="_01_Canvas.MainWindow"
        xmlns         ="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x       ="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d       ="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc      ="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local   ="clr-namespace:_01_Canvas"
        xmlns:comment = "Тег для создания комментариев"
        mc:Ignorable  ="d comment"
        Title         ="MainWindow"
        Height        ="480"
        Width         ="640"
        >
    <Grid>
        <!--Разделение окна на 4 части 2 столбца и 2 строки-->
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        
        <!-- Пример работы с Canvas и его свойствами -->
        <Canvas 
            x:Name      ="MyFirstCanvas"    comment:Name        ="Задает имя и предоставляет ссылку на данный элемент"
            Width       ="280"              comment:Width       ="Задает ширину контейнера"
            MaxWidth    ="290"              comment:MaxWidth    ="Задает максимальную ширину контейнера"
            MinWidth    ="100"              comment:MinWidth    ="Задает минимальную ширину контейнера"
            Height      ="200"              comment:Height      ="Задает высоту контейнера"
            MaxHeight   ="220"              comment:MaxHeight   ="Задает максимальную высоту контейнера"
            Margin      ="10,10,110,254"    comment:Margin      ="Задает внешние отступы (некоторое пространство вокруг элемента)"
            Background  ="Aqua"
                >
        </Canvas>

    </Grid>
</Window>
~~~




