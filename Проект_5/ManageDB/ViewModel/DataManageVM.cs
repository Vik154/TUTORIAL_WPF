using ManageDB.Model;
using ManageDB.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

    // Имя отдела
    public string? DepartmentName { get; set; }

    #region КОМАНДЫ ОТКРЫТИЯ ОКОН ДЛЯ ДОБАВЛЕНИЯ НОВЫХ ЭЛЕМЕНТОВ
    
    private RelayCommand? addNewDepartment;
    public RelayCommand AddNewDepartment {
        get {
            return addNewDepartment ?? new RelayCommand(obj => {
                Window? window = obj as Window;

                string res = "";

                if (string.IsNullOrEmpty(DepartmentName) ||
                    DepartmentName.Replace(" ", "").Length == 0) 
                {
                    SetRedBlockControl(window!, "txtBox");
                }
                else {
                    res = DataWorker.CreateDepartment(DepartmentName);
                    UpdateAllDataView();
                    ShowMessageToUser(res);
                    SetNullValuesToProperties();
                    window?.Close();
                }
            });
        }
    }

    #endregion

    #region КОМАНДЫ ОТКРЫТИЯ ОКОН
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

    #region СЕРВИСНЫЕ МЕТОДЫ

    /// <summary> Подсвечивает рамку ввода красным, если она пустая </summary>
    private void SetRedBlockControl(Window window, string blockName) {
        Control? block = window.FindName(blockName) as Control;
        if (block is null) { return; }
        block.BorderBrush = Brushes.Red;
    }

    /// <summary> Вызывает диалоговое окно уведомления </summary>
    private void ShowMessageToUser(string message) {
        MessageView messageView = new MessageView(message);
        SetCenterPositionAndOpen(messageView);
    }

    #region Обновление VIEW

    /// <summary> Обновление VIEW при изменениях в отделах </summary>
    private void UpdateAllDepartmentsViews() {
        AllDepartments = DataWorker.GetAllDepartments();
        MainWindow.AllDepartmentsView.ItemsSource = null;
        MainWindow.AllDepartmentsView.Items.Clear();
        MainWindow.AllDepartmentsView.ItemsSource = AllDepartments;
        MainWindow.AllDepartmentsView.Items.Refresh();
    }

    /// <summary> Обновление VIEW при изменениях в позициях </summary>
    private void UpdateAllPositionsViews() {
        AllPositions = DataWorker.GetAllPositions();
        MainWindow.AllPositionsView.ItemsSource = null;
        MainWindow.AllPositionsView.Items.Clear();
        MainWindow.AllPositionsView.ItemsSource = AllPositions;
        MainWindow.AllPositionsView.Items.Refresh();
    }

    /// <summary> Обновление VIEW при изменениях в пользователях </summary>
    private void UpdateAllUsersViews() {
        AllUsers = DataWorker.GetAllUsers();
        MainWindow.AllUsersView.ItemsSource = null;
        MainWindow.AllUsersView.Items.Clear();
        MainWindow.AllUsersView.ItemsSource = AllUsers;
        MainWindow.AllUsersView.Items.Refresh();
    }

    /// <summary> Обновление всех VIEW при изменениях </summary>
    private void UpdateAllDataView() {
        UpdateAllDepartmentsViews();
        UpdateAllPositionsViews();
        UpdateAllUsersViews();
    }

    /// <summary> Обнуление полей при изменениях </summary>
    private void SetNullValuesToProperties() {

        DepartmentName = null;
    }

    #endregion

    #endregion
}
