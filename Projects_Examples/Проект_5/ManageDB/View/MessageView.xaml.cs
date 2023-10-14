using System.Windows;

namespace ManageDB.View;

// Кривая логика ! так делать не надо (надо через view model)
public partial class MessageView : Window {

    public MessageView(string message) {
        InitializeComponent();
        MessageText.Text = message;
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e) {
        this.Close();
    }
}
