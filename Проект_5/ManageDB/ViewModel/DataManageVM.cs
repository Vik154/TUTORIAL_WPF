using ManageDB.Model;
using ManageDB.View;
using System.ComponentModel;
using System.Windows;

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

    #region КОМАНДЫ
    private RelayCommand? openAddNewDepartmentWnd;
    public RelayCommand OpenAddNewDepartmentWnd {
        get => openAddNewDepartmentWnd ?? new RelayCommand(obj
            => OpenAddDepartmentWindowMethod());
    }

    private RelayCommand? openAddNewPositionWnd;
    public RelayCommand OpenAddNewPositionWnd {
        get => openAddNewPositionWnd ?? new RelayCommand(obj
            => OpenAddPositionWindowMethod());
    }

    private RelayCommand? openAddNewUserWnd;
    public RelayCommand OpenAddNewUserWnd {
        get => openAddNewUserWnd ?? new RelayCommand(obj
            => OpenAddUserWindowMethod());
    }

    #endregion

    #region МЕТОДЫ ОТКРЫТИЯ ОКОН
    //----------------------------------------------
    // Методы открытия окон
    private void SetCenterPositionAndOpen(Window window) {
        window.Owner = Application.Current.MainWindow;
        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        window.ShowDialog();
    }

    // Методы открытия окон для добавления новых элементов
    private void OpenAddDepartmentWindowMethod() {
        AddNewDepartmentWindow newDepartmentWindow = new AddNewDepartmentWindow();
        SetCenterPositionAndOpen(newDepartmentWindow);
    }

    private void OpenAddPositionWindowMethod() {
        AddNewPositionWindow newPositionWindow = new AddNewPositionWindow();
        SetCenterPositionAndOpen(newPositionWindow);
    }

    private void OpenAddUserWindowMethod() {
        AddNewUserWindow newUserWindow = new AddNewUserWindow();
        SetCenterPositionAndOpen(newUserWindow);
    }

    // Методы открытия окон редактирования элементов 
    private void OpenEditDepartmentWindowMethod() {
        EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow();
        SetCenterPositionAndOpen(editDepartmentWindow);
    }

    private void OpenEditPositionWindowMethod() {
        EditPositionWindow editPositionWindow = new EditPositionWindow();
        SetCenterPositionAndOpen(editPositionWindow);
    }

    private void OpenEditUserWindowMethod() {
        EditUserWindow editUserWindow = new EditUserWindow();
        SetCenterPositionAndOpen(editUserWindow);
    }
    #endregion
}
