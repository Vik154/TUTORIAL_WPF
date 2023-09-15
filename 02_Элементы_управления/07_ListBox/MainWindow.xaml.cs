using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _07_ListBox;

public record class Student(string Name, int Age, int ID, string Group);

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        MakeListBox();
    }

    private void MakeListBox() {
        ListBox listBox = new ListBox();

        listBox.Items.Add(new Student("Tom", 22, 1, "21-A"));
        listBox.Items.Add(new Student("Tim", 23, 2, "21-A"));
        listBox.Items.Add(new Student("Ben", 21, 3, "13-A"));
        listBox.Items.Add(new Student("Bob", 25, 4, "13-A"));
        listBox.Items.Add(new Student("Sam", 24, 5, "13-A"));

        listBox.Background = Brushes.AliceBlue;
        listBox.FontWeight = FontWeights.Bold;
        listBox.FontSize = 16;

        this.Content = listBox;
    }
}
