using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _05_Grid;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
        MakeGrid();
    }

    private void MakeGrid() {
        Grid grid = new Grid();
        grid.ShowGridLines = true;
        grid.ColumnDefinitions.Add(new ColumnDefinition());
        grid.ColumnDefinitions.Add(new ColumnDefinition());
        grid.RowDefinitions.Add(new RowDefinition());
        grid.RowDefinitions.Add(new RowDefinition());

        Rectangle rectangle = new Rectangle { Fill = Brushes.Aqua, Width = 100, Height = 50 };
        Ellipse ellipse = new Ellipse { Fill = Brushes.Aqua, Width = 100, Height = 50 };
        Button button1 = new Button { Content = "Кнопка", Background = Brushes.Beige };
        Button button2 = new Button { Content = "Кнопка", Background = Brushes.Azure };

        grid.Children.Add(rectangle); 
        grid.Children.Add(ellipse);
        grid.Children.Add(button1);
        grid.Children.Add(button2);

        Grid.SetColumn(rectangle, 1);
        Grid.SetRow(rectangle, 0);
        Grid.SetRow(ellipse, 1);
        Grid.SetColumn(ellipse, 0);
        Grid.SetRow(button1, 1);
        Grid.SetColumn(button1, 1);

        this.Content = grid;
    }
}
