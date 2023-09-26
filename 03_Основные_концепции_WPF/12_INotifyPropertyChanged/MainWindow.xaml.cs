using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace _12_INotifyPropertyChanged;

public partial class MainWindow : Window {

    private List<Person> persons;

    public MainWindow() {
        InitializeComponent();

        persons = new List<Person> {
            new Person("Ben", "Lee", 33),
            new Person("Bill", "Ramirez", 36),
            new Person("Bobby", "Allen", 38),
            new Person("Brian", "Murphy", 34),
            new Person("Bruce", "Lopez", 35)
        };

        _list.ItemsSource = persons;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
        Person? person = Resources["person"] as Person;
        if (person != null)
            person.FirstName = "Timmy";
    }
}


public class Person : INotifyPropertyChanged {

    private string lastName  = "";
    private string firstName = "";
    private int age;

    public Person() { }

    public Person(string _firstName, string _lastName, int _age) {
        firstName = _firstName;
        lastName = _lastName;
        age = _age;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = "") {
        if (propertyName != null && PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    public string LastName {
        get { return lastName; }
        set { lastName = value; 
            OnPropertyChanged("LastName"); } 
    }

    public string FirstName {
        get { return firstName; }
        set { firstName = value; OnPropertyChanged("FirstName"); }
    }

    public int Age {
        get { return age; }
        set { age = value; OnPropertyChanged("Age"); }
    }

    public override string ToString() {
        return $"{FirstName}\t{LastName}\t{Age}";
    }
}