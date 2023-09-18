using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace _04_Binding;

public class Person {
    public string Name { get; set; }
    public int Age {  get; set; } 
}

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        // MakeBinding();
    }

    private void MakeBinding() {
        StackPanel stackPanel     = new StackPanel();
        Label      label          = new Label { FontSize = 20d, Content = "Binding" };
        TextBox    sourceTextBox  = new TextBox { Margin = new Thickness(10) };
        TextBox    reciverTextBox = new TextBox { Margin = new Thickness(10) };
        
        stackPanel.Children.Add(label);
        stackPanel.Children.Add(sourceTextBox);
        stackPanel.Children.Add(reciverTextBox);

        Binding binding = new Binding();

        // binding.ElementName = sourceTextBox.Name;
        binding.Source = sourceTextBox;
        binding.Path = new PropertyPath("Text");

        reciverTextBox.SetBinding(TextBox.TextProperty, binding);

        this.Content = stackPanel;
    }
}
