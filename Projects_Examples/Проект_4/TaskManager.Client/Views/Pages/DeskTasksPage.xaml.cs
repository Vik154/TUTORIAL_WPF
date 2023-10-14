using System.Windows.Controls;

namespace TaskManager.Client.Views.Pages;

public partial class DeskTasksPage : Page {
    public Grid TasksGrid { get; private set; }
    public DeskTasksPage() {
        InitializeComponent();
        TasksGrid = tasksGrid;
    }
}
