using System.Windows;
using System.Windows.Media;

namespace _09_LVTrees;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
    }

    // Обход логического дерева
    private void logicBtn_Click(object sender, RoutedEventArgs e) {
        PrintLogicalTree(0, this);
    }

    // Обход визуального дерева
    private void visualBtn_Click(object sender, RoutedEventArgs e) {
        PrintVisualTree(0, this);
    }

    // Обход логического дерева
    private void PrintLogicalTree(int depth, object obj) {
        txt.Text += new string(' ', depth * 4) + $"<{obj.GetType().Name}>\n";

        if (!(obj is DependencyObject)) 
            return;

        foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
            PrintLogicalTree(depth + 1, child);
    }

    // Обход визуального дерева
    private void PrintVisualTree(int depth, object obj) {

        txt.Text += new string(' ', depth * 4) + $"<{obj.GetType().Name}>\n";

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
            PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj as DependencyObject, i));
    }

    private void ClearBtn_Click(object sender, RoutedEventArgs e) {
        txt.Text = string.Empty;
    }
}