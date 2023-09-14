using System.Windows;

namespace _05_ScrollViewer; 

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
    }

    private void UpClick(object sender, RoutedEventArgs e) {
        _scroll.LineUp();
    }

    private void DownClick(object sender, RoutedEventArgs e) {
        _scroll.LineDown();
    }

    private void LeftClick(object sender, RoutedEventArgs e) {
        _scroll.LineLeft();
    }

    private void RightClick(object sender, RoutedEventArgs e) {
        _scroll.LineRight();
    }
}
