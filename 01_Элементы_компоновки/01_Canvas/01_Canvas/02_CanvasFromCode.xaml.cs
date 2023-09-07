// Пример работы с Canvas из кода C# программно
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _01_Canvas; 

public partial class _02_CanvasFromCode : Page {    // Работа с элементами из кода
    
    private Grid   _grid    = new Grid();       // Для работы с гридом из кода С#
    private Canvas _canvas1 = new Canvas();     // Для работы с canvas из кода C# (x:-1; y: 1)
    private Canvas _canvas2 = new Canvas();     // Для работы с canvas из кода C# (x: 1; y: 1)
    private Canvas _canvas3 = new Canvas();     // Для работы с canvas из кода C# (x:-1; y:-1)
    private Canvas _canvas4 = new Canvas();     // Для работы с canvas из кода C# (x: 1; y:-1)


    public _02_CanvasFromCode() {           // Конструктор
        InitializeComponent();              // Инициализация и добавление компонентов

        MakeGridRowCol();                   // Создание Grid-а 4x4
        MakeCanvasRow0Col0();               // Создание холста в левой верхней плоскоти
        MakeCanvasRow0Col1();               // Создание Canvas в правой верхней плоскости
        MakeCanvasRow1Col0();               // Создание Canvas в левой нижней плоскости grid
        MakeCanvasRow1Col1();               // Создание Canvas в правой нижней плоскости grid

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
            Background = new SolidColorBrush(Color.FromRgb(0, 250, 0))  // Цвет фона
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
                   $"Canvas.GetType: {canvas.GetType().Name}\n" +
                   $"Canvas VAlign: {canvas.GetValue(VerticalAlignmentProperty)}\n" +
                   $"Canvas HAlign: {canvas.HorizontalAlignment}\n" +
                   $"Canvas BackColor: {canvas.Background}\n"
        };
        
        // Добавление дочерних контейнеров в родительский (Grid)
        _grid.Children.Add(canvas);
        _grid.Children.Add(text);
        
        // Установка позиции дочерних контейнеров в родителе (Grid)
        Grid.SetRow(canvas, 0);
        Grid.SetColumn(canvas, 1);
        Grid.SetRow(text, 0);
        Grid.SetColumn(text, 1);

        // Создание элементов для добавления в Canvas
        Rectangle rectangle = new Rectangle {
            Height = 30, Width = 60,
            Fill = new SolidColorBrush(Colors.Green)
        };

        Ellipse ellipse = new Ellipse {
            Height = 30, Width = 50,
            Fill = new SolidColorBrush(Colors.Indigo)
        };

        // Добавление элементов в Canvas
        canvas.Children.Add(ellipse);
        canvas.Children.Add(rectangle);

        // Установка положения элементов в контейнере
        Canvas.SetTop(ellipse, 10);
        Canvas.SetLeft(ellipse, 20);
        Canvas.SetRight(rectangle, 20);
        Canvas.SetBottom(rectangle, 15);

        // Отображение в текстовом поле кол-ва элементов
        text.Text += $"Кол-во вложенных элементов: {canvas.Children.Count}";

        // Сохранение ссылки на созданный объект в глобальное свойство для дальнейшей работы
        _canvas2 = canvas;
    }

    /// <summary> Canvas в левой нижней плоскоти грида (x:-1 ; y:-1) </summary>
    private void MakeCanvasRow1Col0() {

        // Создание канваса
        _canvas3 = new Canvas {
            // Выравнивание по верху и левому краю родительского контейнера (Грида)
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Height = 220,
            Width = 220,
            Background = new SolidColorBrush(Colors.LightSalmon)
        };

        // Создание кнопок и добавление в контейнер
        for (int i = 0; i < 11; ++i) {
            
            Button btn = new Button {
                Content = (i).ToString(),
                Background = new SolidColorBrush(Colors.LightSeaGreen),
                FontWeight = FontWeights.Bold
            };

            _canvas3.Children.Add(btn);
            Canvas.SetLeft(btn, i * 20);
            Canvas.SetTop(btn, i * 20);
        }

        _grid.Children.Add(_canvas3);

        Grid.SetRow(_canvas3, 1);
        Grid.SetColumn(_canvas3, 0);
    }

    /// <summary> Canvas в правой нижней плоскоти грида (x:1 ; y:-1) </summary>
    private void MakeCanvasRow1Col1() {

        _canvas4 = new Canvas {
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Width = 220,
            Height = 220,
            Background = new SolidColorBrush(Colors.LightSalmon)
        };

        TextBlock txt = new TextBlock {
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Background = new SolidColorBrush(Colors.LightGray),
            Text = "Инфо:\n"            
        };

        _canvas4.Children.Add(txt);
        Canvas.SetLeft(txt, 60);
        Canvas.SetTop(txt, 0);

        _grid.Children.Add(_canvas4);
        Grid.SetColumn(_canvas4, 1);
        Grid.SetRow(_canvas4, 1);

        foreach (UIElement elem in _grid.Children) {
            txt.Text += elem.GetType().Name + "\n";
        }
    }
}