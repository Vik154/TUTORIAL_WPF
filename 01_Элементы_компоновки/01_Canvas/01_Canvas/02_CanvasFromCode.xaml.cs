// Пример работы с Canvas из кода C# програмно
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _01_Canvas; 

public partial class _02_CanvasFromCode : Page {
    
    private Grid   _grid    = new Grid();       // Для работы с гридом из кода С#
    private Canvas _canvas1 = new Canvas();     // Для работы с canvas из кода C#
    private Canvas _canvas2 = new Canvas();     // Для работы с canvas из кода C#
    private Canvas _canvas3 = new Canvas();     // Для работы с canvas из кода C#
    private Canvas _canvas4 = new Canvas();     // Для работы с canvas из кода C#


    public _02_CanvasFromCode() {
        InitializeComponent();

        MakeGridRowCol();                   // Создание Grid-а 4x4
        MakeCanvasRow0Col0();               // Создание холста в левой верхней плоскоти
        MakeCanvasRow0Col1();

        _CanvasMainPage.Content = _grid;    // Добавление грида в родительский контейнер
    }

    /// <summary> Создание Grid-а </summary>
    private void MakeGridRowCol() {
        Grid grid = new Grid() {
            RowDefinitions    = { new RowDefinition(), new RowDefinition() },
            ColumnDefinitions = { new ColumnDefinition(), new ColumnDefinition() },
            Background        = new SolidColorBrush(Colors.LightBlue),
            ShowGridLines     = true
        };
        _grid = grid;
    }

    /// <summary> Canvas в левой верхней плоскоти грида (x:-1 ; y:1) </summary>
    private void MakeCanvasRow0Col0() {

        // Создание холста
        Canvas canvas = new Canvas {
            Width      = 120,       // Ширина
            Height     = 160,       // Высота
            MaxHeight  = 200,       // Максимальная Высота
            MaxWidth   = 200,       // Максимальная Ширина
            // Цвет фона
            Background = new SolidColorBrush(Color.FromRgb(0, 250, 0))
        };

        // Создание кнопок
        Button btn1 = new Button() { Content = "Кнопка 1" };
        Button btn2 = new Button() { Content = "Кнопка 2" };
        Button btn3 = new Button() { Content = "Кнопка 3" };

        // Добавление кнопок в контейнер
        canvas.Children.Add(btn1);
        canvas.Children.Add(btn2);
        canvas.Children.Add(btn3);

        // Размещение кнопок внутри контейнера
        Canvas.SetBottom(btn1, 20);
        Canvas.SetRight(btn1, 15);

        Canvas.SetLeft(btn2, 30);
        Canvas.SetTop(btn2, 40);
        
        // Для дальнейшей работы сохранение ссылки на созданный объект
        _canvas1 = canvas;

        // Добавление canvas к родительскому элементу (grid)
        _grid.Children.Add(_canvas1);
    }

    /// <summary> Canvas в правой верхней плоскости грида (x:1 ; y:1) </summary>
    private void MakeCanvasRow0Col1() {

        var converter = new GridLengthConverter();

        // Создание canvas
        Canvas canvas = new Canvas {
            // Выравнивание по верху и левому краю родительского контейнера
            VerticalAlignment = System.Windows.VerticalAlignment.Top,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            Height = 100,
            Width  = 200,
            Background = Brushes.LightCoral
        };

        // Для отображения информации из Canvas
        TextBlock text = new TextBlock {
            VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
            HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            Text = $"Описание методов конейнера Canvas:\n" +
                   $"Canvas.GetType: {canvas.GetType().Name}"
        };
        
        // Добавление дочерних контейнеров в родительский
        _grid.Children.Add(canvas);
        _grid.Children.Add(text);
        
        // Установка позиции дочерних контейнеров в родителе
        Grid.SetRow(canvas, 0);
        Grid.SetColumn(canvas, 1);
        Grid.SetRow(text, 0);
        Grid.SetColumn(text, 1);
    }

}
