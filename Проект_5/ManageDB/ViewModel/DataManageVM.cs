using ManageDB.Model;
using System.ComponentModel;

namespace ManageDB.ViewModel;


internal class DataManageVM : INotifyPropertyChanged {

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    // Все отделы
    private List<Department> allDepartments = DataWorker.GetAllDepartments();

    public List<Department> AllDepartments {
        get => allDepartments;
        set {
            allDepartments = value;
            OnPropertyChanged("AllDepartments");
        }
    }

    // Все позиции
    private List<Position> allPositions = DataWorker.GetAllPositions();

    public List<Position> AllPositions {
        get => allPositions;
        set {
            allPositions = value;
            OnPropertyChanged("AllPositions");
        }
    }

    // Все сотрудники
    private List<User> allUsers = DataWorker.GetAllUsers();

    public List<User> AllUsers {
        get => allUsers;
        set {
            allUsers = value;
            OnPropertyChanged("AllUsers");
        }
    }

}
