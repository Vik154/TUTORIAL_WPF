using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _01_Canvas;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
    }

    // Обработка события перемещения мыши
    private void EvMouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
        Point position = e.GetPosition(this);
        _label.Content = $"X: {position.X}; Y: {position.Y}";
    }

    // Возникает при изменении размера Канваса
    private void EvSizeChanged(object sender, SizeChangedEventArgs e) {
        MessageBox.Show($"Размер изменился, сработал обработчик SizeChanged");
    }

    // Нажатие клавиш (в данном случае надо TAB-ом пронажимать и получить фокус на Канвасе)
    private void EvKeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
        MessageBox.Show($"Нажата кнопка {e.Key}", "Инфо", MessageBoxButton.OKCancel);
    }

    // Кнопка для изменения размера Канваса
    private void EvClick(object sender, RoutedEventArgs e) {
        if (_canvas.Height == 200)
            _canvas.Height = 150;
        else
            _canvas.Height = 200;
    }

    /*-- Программное создание Canvas --*/
    private void MakeCanvas() {
        Canvas canvas = new Canvas {    // Программное создание Canvas
            Width = 200,                // Задаёт Ширину
            Height = 200,               // Задаёт Высоту
            Background = Brushes.Aqua,  // Задаёт фон
        };

        Button button = new Button {    // Создание кнопки
            Content = "Кнопка",         // Задает название кнопки
            Background = Brushes.Azure  // Задает фон кнопки
        };

        Ellipse ellipse = new Ellipse { // Создание эллипса
            Height = 50,                // Задает ширину
            Width = 80,                 // Задает высоту
            Fill = Brushes.Brown        // Задает фон
        };

        Rectangle rect = new Rectangle {
            Height = 50,
            Width = 100,
            Fill = Brushes.Blue
        };

        // Добавление элементов в родительский контейнер Canvas
        canvas.Children.Add(button);
        canvas.Children.Add(ellipse);
        canvas.Children.Add(rect);

        // Размещение добавленных элементов внутри Canvas
        Canvas.SetBottom(button, 15);
        Canvas.SetRight(button, 15);
        Canvas.SetLeft(ellipse, 20);
        Canvas.SetTop(ellipse, 10);
        Canvas.SetLeft(rect, 50);
        Canvas.SetTop(rect, 80);

        // Добавление Canvas в родительский контейнер (Window)
        this.Content = canvas;
    }
}
