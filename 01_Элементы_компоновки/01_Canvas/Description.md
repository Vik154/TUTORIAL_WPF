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
~~~C#
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
void DragEnter(object sender, System.Windows.DragEventArgs e);                 // При перетаскивании при вхождении указателя мыши в пределы элемента

    /// <summary> Возникает при перемещении курсора мыши за пределы элемента </summary>
    private void EvDragLeave(object sender, System.Windows.DragEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие DragLeave курсор за пределами\n";
    }

    /// <summary> Возникает при перемещении курсора в пределах границ элемента управления </summary>
    private void EvDragOver(object sender, System.Windows.DragEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие DragOver курсор в пределах границы\n";
    }

    // Возникает при завершении перетаскивания элемента
    private void EvDrop(object sender, System.Windows.DragEventArgs e) {
        Point dropPosition = e.GetPosition(_canvasRow0Col0);

        Canvas.SetLeft(_greenRectangle, dropPosition.X);
        Canvas.SetTop(_greenRectangle, dropPosition.Y);

        _txtRow0Col0.Text = _txtRow0Col0.Text +
            $"Квадрат перемещён в (x: {dropPosition.X}; y: {dropPosition.Y})\n";
    }

    // Происходит при изменении значения свойства Focusable.
    private void EvFocusableChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие FocusableChanged изменении значения свойства Focusable\n";
    }

    // Обработчик нажатия кнопки "Сменить фон"
    private void _btnRow0Col0_Click(object sender, System.Windows.RoutedEventArgs e) {
        _canvasRow0Col0.Background = new SolidColorBrush(
            Color.FromRgb(
                (byte)new Random().Next(0, 255),
                (byte)new Random().Next(0, 255),
                (byte)new Random().Next(0, 255)
            ));
    }

    // Обработчик события перемещения мыши (для зеленого квадратика в данном случае)
    private void _greenRectangle_MouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
        if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed) {
            DragDrop.DoDragDrop(_greenRectangle, _greenRectangle, DragDropEffects.Move);

            _txtRow0Col0.Text = _txtRow0Col0.Text + "Перемещение квадрата с помощью мыши\n";
        }
    }

    // Кнопка для смены значения свойства Focusable и вызова события.
    private void _btnFocusable_Click(object sender, RoutedEventArgs e) {
        if (_canvasRow0Col0.Focusable == true)
            _canvasRow0Col0.Focusable = false;
        else
            _canvasRow0Col0.Focusable = true;
    }

    /// <summary> Возникает постоянно во время операции перетаскивания </summary>
    private void EvGiveFeedback(object sender, GiveFeedbackEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие GiveFeedback Возникает постоянно во время перетаскивания\n";
    }

    /// <summary> Возникает при получении фокуса </summary>
    private void EvGotFocus(object sender, RoutedEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие GotFocus получение фокуса Кнопкой TAB\n";
    }

    /// <summary> Возникает при получении фокуса с помощью клавиатуры </summary>
    private void EvGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие GotKeyboardFocus получение фокуса с помощью клавиатуры\n";
    }

    /// <summary> Возникает при получении фокуса с помощью мыши </summary>
    private void EvGotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие GotMouseCapture получение фокуса с помощью мыши\n";
    }

    /// <summary> Происходит, когда элемент фиксирует события пера. </summary>
    private void EvGotStylusCapture(object sender, System.Windows.Input.StylusEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие GotStylusCapture изменение цвета пера\n";
    }

    /// <summary> Происходит при получении данным элементом операции сенсорного ввода. </summary>
    private void EvGotTouchCapture(object sender, System.Windows.Input.TouchEventArgs e) { }

    /// <summary> Происходит во время инициализации данного FrameworkElement </summary>
    private void EvInitialized(object sender, EventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие Initialized инициализация элемента\n";
        _canvasRow0Col0.IsEnabled = false;
        _canvasRow0Col0.IsEnabled = true;
    }

    /// <summary> Происходит при изменении значения свойства IsEnabled для этого элемента. </summary>
    private void EvIsEnableChanged(object sender, DependencyPropertyChangedEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие IsEnableChanged изменении значения свойства IsEnabled\n";
    }

    /// <summary> Происходит при изменении значения свойства зависимостей IsHitTestVisible для этого элемента. </summary>
    private void EvIsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsMouseDirectyOverChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsStylusCapturedChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsStylusCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsStylusDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e) { }

    private void EvIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) {}

    // Изменить цвет пера, чтобы вызвать событие GotStylusCapture
    private void _btnChangePenColor_Click(object sender, RoutedEventArgs e) {
        _txtRow0Col0.Background = Brushes.AliceBlue;
    }

    private void EvKeyDown(object sender, System.Windows.Input.KeyEventArgs e) { }

    private void EvKeyUp(object sender, System.Windows.Input.KeyEventArgs e) { }

    private void EvLayoutUpdated(object sender, EventArgs e) { }

    private void EvLoaded(object sender, RoutedEventArgs e) { }

    private void EvLostFocus(object sender, RoutedEventArgs e) { }

    private void EvLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) { }

    private void EvLostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e) { }

    private void EvLostStylusCapture(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvLostTouchCapture(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvManipulationBoundaryFeedback(object sender, System.Windows.Input.ManipulationBoundaryFeedbackEventArgs e) { }

    private void EvManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e) { }

    private void EvManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e) { }

    private void EvManipulationIntertiaStarting(object sender, System.Windows.Input.ManipulationInertiaStartingEventArgs e) { }

    private void EvManipulationStared(object sender, System.Windows.Input.ManipulationStartedEventArgs e) { }

    private void EvManipulationStarting(object sender, System.Windows.Input.ManipulationStartingEventArgs e) { }

    private void EvMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvMouseEnter(object sender, System.Windows.Input.MouseEventArgs e) { }

    private void EvMouseLeave(object sender, System.Windows.Input.MouseEventArgs e) { }

    private void EvMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvMouseMove(object sender, System.Windows.Input.MouseEventArgs e) { }

    private void EvMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e) { }

    private void EvPreviewDragEnter(object sender, DragEventArgs e) { }

    private void EvPreviewDragLeave(object sender, DragEventArgs e) { }

    private void EvPreviewDragLOver(object sender, DragEventArgs e) { }

    private void EvPreviewDrop(object sender, DragEventArgs e) { }

    private void EvPreviewGiveFeedback(object sender, GiveFeedbackEventArgs e) { }

    private void EvPreviewGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) { }

    private void EvPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e) { }

    private void EvPreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e) { }

    private void EvPreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e) { }

    private void EvPreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvPreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvPreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e) { }

    private void EvPreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvPreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvPreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e) { }

    private void EvPreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e) { }

    private void EvPreviewQueryContinueDrag(object sender, QueryContinueDragEventArgs e) { }

    private void EvPreviewStylusButtonDown(object sender, System.Windows.Input.StylusButtonEventArgs e) { }

    private void EvPreviewStylusButtonUp(object sender, System.Windows.Input.StylusButtonEventArgs e) { }

    private void EvPreviewStylusDown(object sender, System.Windows.Input.StylusDownEventArgs e) { }

    private void EvPreviewStylusAirMore(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvPreviewStylusInRange(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvPreviewStylusMove(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvPreviewStylusOutOfRange(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvPreviewStylusSystemGesture(object sender, System.Windows.Input.StylusSystemGestureEventArgs e) { }

    private void EvPreviewStylusUp(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) { }

    private void EvPreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvPreviewTouchMove(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvPreviewTouchUp(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvQueryContinueDrag(object sender, QueryContinueDragEventArgs e) { }

    private void EvQueryCursor(object sender, System.Windows.Input.QueryCursorEventArgs e) { }

    private void EvRequestBringIntoView(object sender, RequestBringIntoViewEventArgs e) { }

    private void EvSizeChanged(object sender, SizeChangedEventArgs e) { }

    private void EvSourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e) { }

    private void EvStylusButtonDown(object sender, System.Windows.Input.StylusButtonEventArgs e) { }

    private void EvStylusButtonUp(object sender, System.Windows.Input.StylusButtonEventArgs e) { }

    private void EvStylusDown(object sender, System.Windows.Input.StylusDownEventArgs e) { }

    private void EvStylusEnter(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvStylusInAirMore(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvStylusInRange(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvStylusLeave(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvStylusMove(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvStylusOutOfRange(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvStylusSystemGesture(object sender, System.Windows.Input.StylusSystemGestureEventArgs e) { }

    private void EvStylusUp(object sender, System.Windows.Input.StylusEventArgs e) { }

    private void EvTargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e) { }

    private void EvTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) { }

    private void EvToolTipClosing(object sender, ToolTipEventArgs e) { }

    private void EvToolTipOpening(object sender, ToolTipEventArgs e) { }

    private void EvTouchDown(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvTouchEnter(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvTouchLeave(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvTouchMore(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvTouchUp(object sender, System.Windows.Input.TouchEventArgs e) { }

    private void EvUnloaded(object sender, RoutedEventArgs e) { }
}

~~~
