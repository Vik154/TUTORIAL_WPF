using ManageDB.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ManageDB.View;

public partial class MainWindow : Window {

    // Поля для изменения VIEW при обновлении (ТАК ДЕЛАТЬ НЕ НАДО!)
    public static ListView AllDepartmentsView = new();
    public static ListView AllPositionsView = new();
    public static ListView AllUsersView = new();

    public MainWindow() {
        InitializeComponent();

        // Так делать не надо - говнокод!
        DataContext = new DataManageVM();

        AllDepartmentsView = ViewAllDepartments;
        AllPositionsView = ViewAllPositions;
        AllUsersView = ViewAllUsers;
    }
}
