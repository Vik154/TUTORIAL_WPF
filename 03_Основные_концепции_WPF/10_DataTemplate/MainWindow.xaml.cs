using System.Collections.ObjectModel;
using System.Windows;

namespace _10_DataTemplate;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();

        List<Student> students = new List<Student> {
            new Student { Name = "Иван", SurName = "Иванович", ID = 1},
            new Student { Name = "Пётр", SurName = "Иванович", ID = 2},
            new Student { Name = "Иван", SurName = "Иванович", ID = 3}
        };

        _listStudents.ItemsSource = students;
        _treeView.ItemsSource = new TreeViewPresenter().CityList;
    }
}

public class Student {
    public string Name { get; set; }    = "";
    public string SurName { get; set; } = "";
    public int ID { get; set; }
}

/*----------------------------------------------------------------------*/
/* Для TreeView */
public partial class City {
    public string CityName { get; set; } = "";
    public ObservableCollection<Street> StreetsList { get; set; } = default!;
}

public partial class Street {
    public string StreetName { get; set; } = "";
    public int[] HouseNumber { get; set; } = { 1,2,3 };
}


public partial class TreeViewPresenter : Window {
    public ObservableCollection<City> CityList { get; set; }

    public TreeViewPresenter() {
        CityList = new ObservableCollection<City> {

            new City {
                CityName = "Москва",
                StreetsList = new ObservableCollection<Street> {
                    new Street { StreetName = "Державина"},
                    new Street { StreetName = "Советская"},
                    new Street { StreetName = "Кирова"},
                    new Street { StreetName = "Пролетарская"}
                },
            },

            new City {
                CityName = "Омск",
                StreetsList = new ObservableCollection<Street> {
                    new Street { StreetName = "Державина"},
                    new Street { StreetName = "Советская"},
                    new Street { StreetName = "Кирова"},
                    new Street { StreetName = "Пролетарская"}
                },
            },

            new City {
                CityName = "Томск",
                StreetsList = new ObservableCollection<Street> {
                    new Street { StreetName = "Державина"},
                    new Street { StreetName = "Советская"},
                    new Street { StreetName = "Кирова"},
                    new Street { StreetName = "Пролетарская"}
                },
            }
        };
    }
}
/*----------------------------------------------------------------------*/