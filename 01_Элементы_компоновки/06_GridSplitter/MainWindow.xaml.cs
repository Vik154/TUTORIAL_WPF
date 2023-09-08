using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _06_GridSplitter; 

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MakeGridSplitter();
    }

    // Программное создание GridSplitter
    private void MakeGridSplitter() {

        // Этот код эквивалентен записи Height = "Auto" в XAML
        RowDefinition rowDefinitionAuto = new RowDefinition {
            Height = new GridLength(0, GridUnitType.Auto)
        };

        // Этот код эквивалентен записи Height = "*" в XAML
        RowDefinition rowDefinitionStar1 = new RowDefinition {
            Height = new GridLength(1, GridUnitType.Star)
        };

        // Потому что WPF запрещает владеть одним элементом нескольким контейнерам
        RowDefinition rowDefinitionStar2 = new RowDefinition {
            Height = new GridLength(1, GridUnitType.Star)
        };

        ColumnDefinition columnDefinitionAuto = new ColumnDefinition {
            Width = new GridLength(0, GridUnitType.Auto)
        };

        ColumnDefinition columnDefinitionStar1 = new ColumnDefinition {
            Width = new GridLength(1, GridUnitType.Star)
        };

        ColumnDefinition columnDefinitionStar2 = new ColumnDefinition {
            Width = new GridLength(1, GridUnitType.Star)
        };

        Grid grid = new Grid();
        grid.RowDefinitions.Add(rowDefinitionStar1);
        grid.RowDefinitions.Add(rowDefinitionAuto);
        grid.RowDefinitions.Add(rowDefinitionStar2);
        grid.ColumnDefinitions.Add(columnDefinitionStar1);
        grid.ColumnDefinitions.Add(columnDefinitionAuto);
        grid.ColumnDefinitions.Add(columnDefinitionStar2);

        Button btn1 = new Button { Background = Brushes.AliceBlue, Content = "Кнопка 1" };
        Button btn2 = new Button { Background = Brushes.Aqua, Content = "Кнопка 2" };
        Button btn3 = new Button { Background = Brushes.Azure, Content = "Кнопка 3" };

        grid.Children.Add(btn1);
        grid.Children.Add(btn2);
        grid.Children.Add(btn3);

        Grid.SetColumn(btn1, 0);
        Grid.SetRow(btn1, 0);
        Grid.SetColumn(btn2, 2);
        Grid.SetRow(btn2, 0);

        Grid.SetColumn(btn3, 0);
        Grid.SetRow(btn3, 2);
        Grid.SetColumnSpan(btn3, 3);

        GridSplitter horzGridSplitter = new GridSplitter {
            Background = Brushes.Gray,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Stretch,
            ShowsPreview = false,
            Width = 15
        };

        GridSplitter vertGridSplitter = new GridSplitter {
            Height = 15,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
            Background = Brushes.Gray
        };

        grid.Children.Add(vertGridSplitter);
        grid.Children.Add(horzGridSplitter);

        Grid.SetColumn(horzGridSplitter, 1);
        Grid.SetRow(horzGridSplitter, 0);

        Grid.SetColumn(vertGridSplitter, 0);
        Grid.SetRow(vertGridSplitter, 1);
        Grid.SetColumnSpan(vertGridSplitter, 3);

        this.Content = grid;
    }
}
