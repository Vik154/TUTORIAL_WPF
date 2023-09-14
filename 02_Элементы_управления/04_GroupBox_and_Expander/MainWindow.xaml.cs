using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _04_GroupBox_and_Expander;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        MakeGroupBox();
    }

    // Программное создание GroupBox
    private void MakeGroupBox() {
        GroupBox groupBox = new GroupBox {
            Header = "Список языков",
            Margin = new Thickness(10),
            Padding = new Thickness(5),
            Background = Brushes.AliceBlue
        };

        StackPanel stackPanel = new StackPanel();
        CheckBox checkBox1 = new CheckBox { Content = "C++",  Margin = new Thickness(5) };
        CheckBox checkBox2 = new CheckBox { Content = "C",    Margin = new Thickness(5) };
        CheckBox checkBox3 = new CheckBox { Content = "C#",   Margin = new Thickness(5) };
        CheckBox checkBox4 = new CheckBox { Content = "Java", Margin = new Thickness(5) };

        stackPanel.Children.Add(checkBox1);
        stackPanel.Children.Add(checkBox2);
        stackPanel.Children.Add(checkBox3);
        stackPanel.Children.Add(checkBox4);

        groupBox.Content = stackPanel;
        this.Content = groupBox;
    }
}
