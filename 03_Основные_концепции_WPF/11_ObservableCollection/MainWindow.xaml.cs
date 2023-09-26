using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _11_ObservableCollection;

public record class Person(string? Name, string? SurName, int Age);

public partial class MainWindow : Window {

    ObservableCollection<Person> people { get; set; }

    Window Employess = new Employees();

    public MainWindow() {
        InitializeComponent();

        people = new ObservableCollection<Person> {
            new Person("Tom", "Tomson", 22),
            new Person("Bob", "Bobson", 25),
            new Person("Sam", "Samson", 28),
            new Person("Tim", "Timson", 33),
            new Person("Nik", "Nikson", 34)
        };

        _listBox.ItemsSource = people;
        Employess.Show();
    }

    private void AddPerson_Click(object sender, RoutedEventArgs e) {
        if (_txtAge.Text == string.Empty)
            _txtAge.Text = "150";

        var newUser = new Person(_txtName.Text, _txtSur.Text, Convert.ToInt32(_txtAge.Text));
        people.Add(newUser);
    }

    private void _txtAge_PreviewTextInput(object sender, TextCompositionEventArgs e) {
        e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
    }
}