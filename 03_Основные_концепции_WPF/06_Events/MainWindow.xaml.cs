using System.Windows;
using System.Windows.Input;

namespace _06_Events;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

    }
    int i = 0;

    private void Bubble_MouseUp(object sender, MouseButtonEventArgs e) {
        textBlockInfo.Text += new string('*', 50) + $"\nОбъект: {sender} \n" +
            $"Источник: {e.Source} \nНачальный источник: {e.OriginalSource}\n";
    }

    private void Tunnel_MouseUp(object sender, MouseButtonEventArgs e) {
        ++i;
        textBlockInfo.Text += new string('*', 50) + $"\n{i}. \nОбъект: {sender} \n" +
            $"Источник: {e.Source} \nНачальный источник: {e.OriginalSource}\n";
    }
}
