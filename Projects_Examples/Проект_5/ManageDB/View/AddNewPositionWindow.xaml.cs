using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ManageDB.View;

public partial class AddNewPositionWindow : Window {
    public AddNewPositionWindow() {
        InitializeComponent();
    }

    // Ввод только цифр
    private void PreviewTextInput(object sender, TextCompositionEventArgs e) {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}
