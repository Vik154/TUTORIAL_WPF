using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _01_Canvas;

public partial class MainWindow : Window {

    private List<Page> Pages { get; set; } = new List<Page>();

    public MainWindow() {
        InitializeComponent();
        Pages.Add(new _01_CanvasBase());
        Pages.Add(new _02_CanvasFromCode());
        Pages.Add(new _03_CanvasEvents());

    }

    /// <summary> Отображает страницу 01_CanvasBase </summary>
    private void _01_Canvas_Click(object sender, RoutedEventArgs e) { 
        _frame.Content = Pages[0];
    }

    /// <summary> Отображает страницу 02_CanvasFromCode </summary>
    private void _02_Canvas_Click(object sender, RoutedEventArgs e) {
        _frame.Content = Pages[1];
    }

    /// <summary> Отображает страницу 03_CanvasEvents </summary>
    private void _03_Canvas_Click(object sender, RoutedEventArgs e) {
        _frame.Content = Pages[2];
    }
}
