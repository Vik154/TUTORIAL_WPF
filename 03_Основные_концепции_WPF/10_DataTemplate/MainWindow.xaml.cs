using System.Windows;

namespace _10_DataTemplate;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();

        List<Student> students = new List<Student> {
            new Student { Name = "Иван", SurName = "Иванович", ID = 1},
            new Student { Name = "Иван", SurName = "Иванович", ID = 2},
            new Student { Name = "Иван", SurName = "Иванович", ID = 3}
        };

        _listStudents.ItemsSource = students;
    }
}

public class Student {
    public string Name { get; set; }    = "";
    public string SurName { get; set; } = "";
    public int ID { get; set; }
}