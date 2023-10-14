using Microsoft.Xaml.Behaviors;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_TEST.Behaviors;

public class DragInCanvas : Behavior<UIElement> {

    private Point _StartPoint;
    private Canvas? _Canvas;

    #region PositionX : double - Горизонтальное смещение

    /// <summary>Горизонтальное смещение</summary>
    public static readonly DependencyProperty PositionXProperty =
        DependencyProperty.Register(
            nameof(PositionX),
            typeof(double),
            typeof(DragInCanvas),
            new PropertyMetadata(default(double)));

    /// <summary>Горизонтальное смещение</summary>
    //[Category("")]
    [Description("Горизонтальное смещение")]
    public double PositionX {
        get => (double)GetValue(PositionXProperty);
        set => SetValue(PositionXProperty, value);
    }

    #endregion

    #region PositionY : double - Вертикальное положение

    /// <summary>Вертикальное положение</summary>
    public static readonly DependencyProperty PositionYProperty =
        DependencyProperty.Register(
            nameof(PositionY),
            typeof(double),
            typeof(DragInCanvas),
            new PropertyMetadata(default(double)));

    /// <summary>Вертикальное положение</summary>
    //[Category("")]
    [Description("Вертикальное положение")]
    public double PositionY {
        get => (double)GetValue(PositionYProperty);
        set => SetValue(PositionYProperty, value);
    }

    #endregion

    // Когда элемент добавляется в коллекцию
    // Чтобы реализовать поведение - нужно реализовать эти два метода,
    // которые подписываются и отписываются на события визуального элемента
    protected override void OnAttached() {
        AssociatedObject.MouseLeftButtonDown += OnButtonDown;
    }

    // Когда элемент удаляется из коллекции
    protected override void OnDetaching() {
        AssociatedObject.MouseLeftButtonDown -= OnButtonDown;
        AssociatedObject.MouseMove -= OnMouseMove;
        AssociatedObject.MouseUp -= OnMouseUp;
    }

    private void OnButtonDown(object sender, MouseButtonEventArgs e) {
        
        if ((_Canvas ??= VisualTreeHelper.GetParent(AssociatedObject) as Canvas) is null) {
            return;
        }
        
        _StartPoint = e.GetPosition(AssociatedObject);
        AssociatedObject.CaptureMouse();
        AssociatedObject.MouseMove += OnMouseMove;
        AssociatedObject.MouseUp += OnMouseUp;
    }

    private void OnMouseUp(object sender, MouseButtonEventArgs e) {
        AssociatedObject.MouseMove -= OnMouseMove;
        AssociatedObject.MouseUp -= OnMouseUp;
        AssociatedObject.ReleaseMouseCapture();
    }

    private void OnMouseMove(object sender, MouseEventArgs e) {
        var obj = AssociatedObject;
        var current_pos = e.GetPosition(_Canvas);

        var delta = current_pos - _StartPoint;

        obj.SetValue(Canvas.LeftProperty, delta.X);
        obj.SetValue(Canvas.TopProperty, delta.Y);

        PositionX = delta.X;
        PositionY = delta.Y;
    }
}
