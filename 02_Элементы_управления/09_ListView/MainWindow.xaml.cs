using System.Windows;

namespace _09_ListView;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }
}

public class EmployeeInfoDataSource {
    public string? FirstName { get; set; }
    public string? LastName  { get; set; }
    public int Number {  get; set; }
}