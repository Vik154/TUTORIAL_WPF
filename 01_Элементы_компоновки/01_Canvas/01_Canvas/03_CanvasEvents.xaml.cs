// Примеры работы с событиями в Canvas 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _01_Canvas;

public partial class _03_CanvasEvents : Page {

    public _03_CanvasEvents() {
        InitializeComponent();
    }

    /// <summary> Срабатывает при закрытии контекстного меню </summary>
    private void EvContextMenuClosing(object sender, ContextMenuEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Произошло закрытие контекстного меню\n";
        _txtRow0Col0.Text = _txtRow0Col0.Text + $"Источник {e.Source}\n";
    }

    /// <summary> Срабатывает при открытии контекстного меню </summary>
    private void EvContextMenuOpening(object sender, ContextMenuEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Открытие контекстного меню\n";
    }

    /// <summary> Срабатывает при изменении данных, при привязке данных (Binding) </summary>
    private void EvDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Изменение свойства зависимости\n";
        _txtRow0Col0.Text = _txtRow0Col0.Text + $"OLD: {e.OldValue}\n";
        _txtRow0Col0.Text = _txtRow0Col0.Text + $"NEW: {e.NewValue}\n";
    }

    /// <summary> Возникает при перетаскивании при вхождении указателя мыши в пределы элемента </summary>
    private void EvDragEnter(object sender, System.Windows.DragEventArgs e) {
        _txtRow0Col0.Text = _txtRow0Col0.Text + "Событие DragEnter Вхождение указателя мыши в пределы элемента\n";
    }

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
