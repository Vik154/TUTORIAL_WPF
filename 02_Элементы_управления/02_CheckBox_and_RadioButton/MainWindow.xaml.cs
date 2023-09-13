using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _02_CheckBox_and_RadioButton;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
        // MakeCheckBox();
    }

    // Программное добавление флажков
    private void MakeCheckBox() {
        StackPanel wrapPanel = new StackPanel { Background = Brushes.AliceBlue };

        for (int i = 0; i < 10; i++) {
            CheckBox checkBox = new CheckBox {
                Content = $"Check {i + 1}",
                Margin = new Thickness(5),
                Background = new SolidColorBrush(Color.FromRgb(
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255),
                    (byte)new Random().Next(0, 255)
                    )),
                IsChecked = i % 2 == 0? true : false,
            };
            wrapPanel.Children.Add(checkBox);
        }
        this.Content = wrapPanel;
    }

    private void bigCheckBox_Checked(object sender, RoutedEventArgs e) {
        MessageBox.Show(bigCheckBox.Content.ToString() + " отмечен");
    }

    private void bigCheckBox_Unchecked(object sender, RoutedEventArgs e) {
        MessageBox.Show(bigCheckBox.Content.ToString() + " не отмечен");
    }

    private void bigCheckBox_Indeterminate(object sender, RoutedEventArgs e) {
        MessageBox.Show(bigCheckBox.Content.ToString() + " в неопределенном состоянии");
    }
}
