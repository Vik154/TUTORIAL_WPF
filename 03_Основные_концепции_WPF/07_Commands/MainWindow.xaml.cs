using System.Windows;
using System.Windows.Input;

namespace _07_Commands;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        //CommandBinding commandBinding = new CommandBinding(ApplicationCommands.Help);
        //commandBinding.Executed += new ExecutedRoutedEventHandler(MyLogical);

        //btn.CommandBindings.Add(commandBinding);
    }

    // Обработчик для команды
    //private void MyLogical(object sender, ExecutedRoutedEventArgs e) {
    //    txtInfo.Text += $"Вызвана команда HELP\nИсточник: {e.Source}\n";
    //}
}
