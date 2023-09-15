using System.Windows;
using System.Windows.Controls;

namespace _08_ComboBox;

public record class Person(string Name, string Company, int ID);

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        MakeComboBox();
    }

    private void MakeComboBox() {
        ComboBox comboBox = new ComboBox();
        StackPanel stackPanel = new StackPanel();

        comboBox.Items.Add(new Person("Tom", "Microsoft", 1));
        comboBox.Items.Add(new Person("Tim", "Yandex", 2));
        comboBox.Items.Add(new Person("Tor", "Google", 3));

        comboBox.IsEditable = true;
        comboBox.Text = "Сотрудники";

        stackPanel.Children.Add(comboBox);

        this.Content = stackPanel;
    }
}
