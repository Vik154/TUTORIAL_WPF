using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace _11_ObservableCollection;

// Класс окна
public partial class Employees : Window {

    public Employees() {
        InitializeComponent();

        // ListBox listBox = new ListBox();
        //listBox.ItemsSource = new EmployeesList().Peoples;
        //this.Content = listBox;
    }
}

// Список работников
public class EmployeesList : ObservableCollection<People> {

    private static List<People> peoples = RandomPeopleGenerator.Generate();

    public EmployeesList() : base(peoples) { }

    public List<People> Peoples { get; set; } = peoples;
}

// Компании
public enum Company { Microsoft, Google, Yandex, MailGroup }

// Работник
public class People {
    public string  FirstName { get; set; } = string.Empty;
    public string  LastName  { get; set; } = string.Empty;
    public Company Company   { get; set; }
    public uint Phone { get; set; }

    public People() { }
    public People(string firstName, string lastName, Company company, uint phone) {
        FirstName = firstName;
        LastName = lastName;
        Company = company;
        Phone = phone;
    }

    public override string ToString() {
        return $"{FirstName} {LastName} {Company} {Phone}";
    }
}

// Рандомная генерация данных
public static class RandomPeopleGenerator {

    static readonly List<string> FirstNames;
    static readonly List<string> LastNames;
    static readonly List<uint>   Phones;

    static RandomPeopleGenerator() {
        FirstNames = new List<string> { "Aaron", "Adrian", "Alexander", "Arthur",
            "Austen", "Ben", "Benjamin", "Bill", "Brian", "Bobby", "Brandon", "Bruce",
            "Calvin", "Charles", "Adriana", "Aimee", "Alice", "Amanda", "Amy", "Andrea",
            "Angelina", "Ariel", "Arya", "Audrey", "Beatrice", "Beverly", "Britney" };

        LastNames = new List<string> { "Moore", "Jackson", "Harris", "Rodriguez",
            "Lee", "Allen", "Lopez", "Ramirez", "Murphy", "Stewart", "Griffin",
            "Watson", "Parker", "Collins", "Washington", "Garcia" };

        Phones = new List<uint>();

        for (int j = 0; j < 20; ++j)
            Phones.Add((uint)(new Random().Next(1 << 30)) << 2 | 
                (uint)(new Random().Next(1 << 2)));        
    }

    public static List<People> Generate() { 
        List<People> peoples = new List<People>();

        for (int i = 0; i < 20; ++i) {
            peoples.Add(new People {
                FirstName = FirstNames[new Random().Next(0, FirstNames.Count)],
                LastName  = LastNames[new Random().Next(0, LastNames.Count)],
                Company   = (Company)(new Random().Next(0,4)),
                Phone     = Phones[new Random().Next(0, Phones.Count)]
            });
        }
        return peoples;
    }
}