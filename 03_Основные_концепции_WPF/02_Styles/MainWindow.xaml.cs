using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _02_Styles;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        MakeStyles();
    }

    // Создание стилей из кода
    private void MakeStyles() {

        StackPanel stackPanel = new StackPanel();
        Button button1 = new Button { Content = "Кнопка 1", Name = "bt1" };
        Button button2 = new Button { Content = "Кнопка 2", Name = "bt2" };
        Button button3 = new Button { Content = "Кнопка 3", Name = "bt3" };

        stackPanel.Children.Add(button1);
        stackPanel.Children.Add(button2);
        stackPanel.Children.Add(button3);

        Style myButtonStyle = new Style { TargetType = typeof(Button) };
        myButtonStyle.Setters.Add(new Setter { Property = Button.WidthProperty,  Value = 100d });
        myButtonStyle.Setters.Add(new Setter { Property = Button.HeightProperty, Value = 30d });
        myButtonStyle.Setters.Add(new Setter { Property = FontSizeProperty, Value = 18d });
        myButtonStyle.Setters.Add(new Setter { Property = FontWeightProperty, Value = FontWeights.Bold });
        myButtonStyle.Setters.Add(new Setter { Property = BackgroundProperty, Value = Brushes.Aquamarine });
        myButtonStyle.Setters.Add(new Setter { Property = HorizontalAlignmentProperty, Value = HorizontalAlignment.Left });
        myButtonStyle.Setters.Add(new Setter { Property = MarginProperty, Value = new Thickness(10) });

        myButtonStyle.Setters.Add(new EventSetter { Event = Button.ClickEvent, Handler = new RoutedEventHandler(buttonSetColorCode) });

        button1.Style = myButtonStyle;
        button2.Style = myButtonStyle;
        button3.Style = myButtonStyle;

        this.Content = stackPanel;
    }

    private void buttonSetColorCode(object sender, RoutedEventArgs e) {
        ((Button)sender).Background = Brushes.Beige;
    }

    private void buttonSetColor(object sender, RoutedEventArgs e) {
        if (((Button)sender).Name == "bt1")      bt2.Background = Brushes.Green;
        else if (((Button)sender).Name == "bt2") bt3.Background = Brushes.Red;
        else if (((Button)sender).Name == "bt3") bt1.Background = Brushes.Bisque;
    }

    private void mousePosition(object sender, MouseEventArgs e) {
        txt.Content = $"Позиция X: {e.GetPosition(this).X}; Y: {e.GetPosition(this).Y};";
    }
}
