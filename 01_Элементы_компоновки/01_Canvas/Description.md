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
        xmlns:comment ="Тег для создания комментариев"
        mc:Ignorable  ="d comment"
        Title         ="MainWindow"
        Height        ="480"
        Width         ="640"
        >
    <Grid>
        <!-- Пример работы с Canvas и его свойствами -->
        <Canvas
            x:Name      ="MyFirstCanvas"    comment:Name        ="Задает имя и предоставляет ссылку на данный элемент"
            Width       ="280"              comment:Width       ="Задает ширину контейнера"
            MaxWidth    ="290"              comment:MaxWidth    ="Задает максимальную ширину контейнера"
            MinWidth    ="100"              comment:MinWidth    ="Задает минимальную ширину контейнера"
            Height      ="200"              comment:Height      ="Задает высоту контейнера"
            MaxHeight   ="220"              comment:MaxHeight   ="Задает максимальную высоту контейнера"
            MinHeight   ="110"              comment:MinHeight   ="Задает минимальную высоту контейнера"
            Margin      ="10,10,110,254"    comment:Margin      ="Задает внешние отступы (некоторое пространство вокруг элемента)"
            Background  ="#FF227C7C"        comment:Background  ="Задает задний фон элемента"
            AllowDrop   ="True"             comment:AllowDrop   ="Свойство разрешающее участвовать элементу в операциях перетаскивания."
            
            BindingGroup    ="{Binding}"    comment:BindingGroup    ="Создает связь между несколькими привязками, которые можно проверять и обновлять вместе"
            CacheMode       ="{Binding}"    comment:CacheMode       ="Используется для повышения производительности отрисовки сложного элемента UIElement"
            Clip            ="{Binding}"    comment:Clip            ="Задает геометрию, используемую для определения контура содержимого элемента"
            ClipToBounds    ="True"         comment:ClipToBounds    ="true, если содержимое необходимо отсечь, по умолчанию — false"
            ContextMenu     ="{Binding}"    comment:ContextMenu     ="Задает элемент контекстного меню"
            Cursor          ="IBeam"        comment:Cursor          ="Установка курсора, который отображается при наведении указателя мыши на этот элемент."
            DataContext     ="{Binding}"    comment:DataContext     ="Задает контекст данных для элемента, участвующего в привязке данных."
            Effect          ="{Binding}"    comment:Effect          ="Задает эффект растрового изображения, который применяется к объекту UIElement."
            FlowDirection   ="LeftToRight"  comment:FlowDirection   ="Задает направление потока текста и других элементов пользовательского интерфейса"
            Focusable       ="False"        comment:Focusable       ="true, если данный элемент может иметь фокус, иначе — false (по умолчанию)"
            FocusVisualStyle="{Binding}"    comment:FocusVisualStyle="Задает стиль элемента при получении фокуса"
            ForceCursor     ="False"        comment:ForceCursor     ="Следует ли принудительно отображать курсор в пользовательском интерфейсе, объявленный свойством Cursor"
            InputScope      ="Number"       comment:InputScope      ="Область ввода, которая изменяет интерпретацию ввода с помощью альтернативных методов"
            IsEnabled       ="True"         comment:IsEnabled       ="Указывает, включен ли этот элемент в пользовательском интерфейсе, по умолчанию - true"
            IsHitTestVisible="True"         comment:IsHitTestVisible="Проверка попадания по элементу; true, если этот элемент может возвращаться в результате проверки"
            Language        ="ru-ru"        comment:Language        ="Задает сведения о языке локализации и глобализации"         
            LayoutTransform ="Identity"     comment:LayoutTransform ="Задает графическое преобразование, которое применяется к элементу"
            Opacity         ="1"            comment:Opacity         ="Задает коэффициент непрозрачности от 0,1 до 1,0, применяемый ко всем UIElement при отрисовке"
            OpacityMask     ="Beige"        comment:OpacityMask     ="Задает маску непрозрачности"
            Style           ="{Binding}"    comment:Style           ="Задает стиль, который должен использоваться этим элементом при его отрисовке"
            Tag             ="MyCanvasTag"  comment:Tag             ="Установка произвольного значения объекта, которое может использоваться для хранения особых сведений об этом элементе."
            ToolTip         ="Подсказка"    comment:ToolTip         ="Задает объект подсказки, отображаемый для этого элемента"
            Uid             ="UNIQGUID"     comment:Uid             ="Задает уникальный строковый идентификатор (в целях локализации) для этого элемента"
            Visibility      ="Visible"      comment:Visibility      ="Задает видимость этого элемента в пользовательском интерфейсе."
        >            
        </Canvas>

    </Grid>
</Window>
~~~

#### Программное создание Canvas
~~~CS
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        Canvas canvas     = new Canvas();
        canvas.Name       = "MyCanvas";
        canvas.Height     = 200;
        canvas.Width      = 200;
        canvas.MinHeight  = 20;
        canvas.MaxHeight  = 220;
        canvas.MinWidth   = 20;
        canvas.MaxWidth   = 220;
        canvas.Margin     = new Thickness(10, 10, 5, 5);
        canvas.Background = Brushes.LightBlue;
        canvas.Cursor     = Cursors.Pen;

        this.Content      = canvas;
    }
}
~~~

#### События унаследованные от класса UIElement
~~~C#
void ContextMenuClosing(object sender, ContextMenuEventArgs e);                // Срабатывает при закрытии контекстного меню 
void ContextMenuOpening(object sender, ContextMenuEventArgs e);                // Срабатывает при открытии контекстного меню 
void DataContextChanged(object sender, DependencyPropertyChangedEventArgs e);  // Срабатывает при изменении данных, при привязке данных (Binding)
void DragEnter(object sender, DragEventArgs e);                                // При перетаскивании при вхождении указателя мыши в пределы элемента
void DragLeave(object sender, DragEventArgs e);                                // Возникает при перемещении курсора мыши за пределы элемента
void DragOver(object sender, DragEventArgs e);                                 // Возникает при перемещении курсора в пределах границ элемента управления
void Drop(object sender, DragEventArgs e);                                     // Возникает при завершении перетаскивания элемента
void FocusableChanged(object sender, DependencyPropertyChangedEventArgs e);    // Происходит при изменении значения свойства Focusable
void GiveFeedback(object sender, GiveFeedbackEventArgs e);                     // Возникает постоянно во время операции перетаскивания
void GotFocus(object sender, RoutedEventArgs e);                               // Возникает при получении фокуса
void GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e);         // Возникает при получении фокуса с помощью клавиатуры
void GotMouseCapture(object sender, MouseEventArgs e);                         // Возникает при получении фокуса с помощью мыши 
void GotStylusCapture(object sender, StylusEventArgs e);                       // Происходит, когда элемент фиксирует события пера
void GotTouchCapture(object sender, TouchEventArgs e);                         // Происходит при получении данным элементом операции сенсорного ввода
void Initialized(object sender, EventArgs e);                                  // Происходит во время инициализации данного FrameworkElement
void IsEnableChanged(object sender, DependencyPropertyChangedEventArgs e);     // Происходит при изменении значения свойства IsEnabled для этого элемента.

void IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e);         // Происходит при изменении значения свойства зависимостей IsHitTestVisible для этого элемента. 
void IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e);        // Происходит при изменении значения свойства IsKeyboardFocused данного элемента
void IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e);    // Происходит при изменении значения свойства IsKeyboardFocusWithin данного элемента.
void IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e);          // Происходит при изменении значения свойства IsMouseCaptured данного элемента.
void IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e);     // Происходит при изменении значения поля IsMouseCaptureWithinProperty данного элемента.
void IsMouseDirectyOverChanged(object sender, DependencyPropertyChangedEventArgs e);
void IsStylusCapturedChanged(object sender, DependencyPropertyChangedEventArgs e);
void IsStylusCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e);
void IsStylusDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e);
void IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e);

void KeyDown(object sender, KeyEventArgs e) { }
void KeyUp(object sender, KeyEventArgs e) { }
void LayoutUpdated(object sender, EventArgs e) { }
void Loaded(object sender, RoutedEventArgs e) { }
void LostFocus(object sender, RoutedEventArgs e) { }
void LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) { }
void LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e) { }
void LostStylusCapture(object sender, System.Windows.Input.StylusEventArgs e) { }
void LostTouchCapture(object sender, System.Windows.Input.TouchEventArgs e) { }
void ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e) { }
void ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e) { }
void ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e) { }
void ManipulationIntertiaStarting(object sender, ManipulationInertiaStartingEventArgs e) { }
void ManipulationStared(object sender, System.Windows.Input.ManipulationStartedEventArgs e) { }
void ManipulationStarting(object sender, System.Windows.Input.ManipulationStartingEventArgs e) { }
void MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) { }
void MouseLeave(object sender, System.Windows.Input.MouseEventArgs e) { }
void MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void MouseMove(object sender, System.Windows.Input.MouseEventArgs e) { }
void EvMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e) { }
void EvPreviewDragEnter(object sender, DragEventArgs e) { }
void EvPreviewDragLeave(object sender, DragEventArgs e) { }
void EvPreviewDragLOver(object sender, DragEventArgs e) { }
void EvPreviewDrop(object sender, DragEventArgs e) { }
void EvPreviewGiveFeedback(object sender, GiveFeedbackEventArgs e) { }
void EvPreviewGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) { }
void EvPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) { }
void EvPreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e) { }
void EvPreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) { }
void EvPreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvPreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvPreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e) { }
void EvPreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvPreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvPreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }
void EvPreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e) { }
void EvPreviewQueryContinueDrag(object sender, QueryContinueDragEventArgs e) { }
void EvPreviewStylusButtonDown(object sender, System.Windows.Input.StylusButtonEventArgs e) { }
void EvPreviewStylusButtonUp(object sender, System.Windows.Input.StylusButtonEventArgs e) { }
void EvPreviewStylusDown(object sender, System.Windows.Input.StylusDownEventArgs e) { }
void EvPreviewStylusAirMore(object sender, System.Windows.Input.StylusEventArgs e) { }
void EvPreviewStylusInRange(object sender, System.Windows.Input.StylusEventArgs e) { }
void EvPreviewStylusMove(object sender, System.Windows.Input.StylusEventArgs e) { }
void EvPreviewStylusOutOfRange(object sender, System.Windows.Input.StylusEventArgs e) { }
void EvPreviewStylusSystemGesture(object sender, System.Windows.Input.StylusSystemGestureEventArgs e) { }
void EvPreviewStylusUp(object sender, System.Windows.Input.StylusEventArgs e) { }
void EvPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) { }
void EvPreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e) { }
void EvPreviewTouchMove(object sender, System.Windows.Input.TouchEventArgs e) { }
void EvPreviewTouchUp(object sender, System.Windows.Input.TouchEventArgs e) { }
void EvQueryContinueDrag(object sender, QueryContinueDragEventArgs e) { }
void EvQueryCursor(object sender, System.Windows.Input.QueryCursorEventArgs e) { }
void EvRequestBringIntoView(object sender, RequestBringIntoViewEventArgs e) { }
void EvSizeChanged(object sender, SizeChangedEventArgs e) { }
void EvSourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e) { }
void EvStylusButtonDown(object sender, System.Windows.Input.StylusButtonEventArgs e) { }
void EvStylusButtonUp(object sender, System.Windows.Input.StylusButtonEventArgs e) { }
void EvStylusDown(object sender, System.Windows.Input.StylusDownEventArgs e)
void EvStylusEnter(object sender, System.Windows.Input.StylusEventArgs e) 
void EvStylusInAirMore(object sender, System.Windows.Input.StylusEventArgs e)
void EvStylusInRange(object sender, System.Windows.Input.StylusEventArgs e)
void EvStylusLeave(object sender, System.Windows.Input.StylusEventArgs e)
void EvStylusMove(object sender, System.Windows.Input.StylusEventArgs e) 
void EvStylusOutOfRange(object sender, System.Windows.Input.StylusEventArgs e)
void EvStylusSystemGesture(object sender, System.Windows.Input.StylusSystemGestureEventArgs e)
void EvStylusUp(object sender, System.Windows.Input.StylusEventArgs e)
void EvTargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
void EvTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
void EvToolTipClosing(object sender, ToolTipEventArgs e)
void EvToolTipOpening(object sender, ToolTipEventArgs e)
void EvTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
void EvTouchEnter(object sender, System.Windows.Input.TouchEventArgs e)
void EvTouchLeave(object sender, System.Windows.Input.TouchEventArgs e) 
void EvTouchMore(object sender, System.Windows.Input.TouchEventArgs e)
void EvTouchUp(object sender, System.Windows.Input.TouchEventArgs e) 
void EvUnloaded(object sender, RoutedEventArgs e) 
~~~
