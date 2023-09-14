using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _03_ToolTip_and_Popup;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        // MakeToolTip();
        // MakeToolTipService();
    }

    // Работа с 
    private void MakeToolTipService() {
        //Create and Ellipse with the BulletDecorator as the tooltip
        Ellipse ellipse2 = new Ellipse();
        ellipse2.Name = "ellipse2";
        this.RegisterName(ellipse2.Name, ellipse2);
        ellipse2.Height = 150;
        ellipse2.Width = 200;
        ellipse2.Fill = Brushes.Aqua;
        ellipse2.HorizontalAlignment = HorizontalAlignment.Left;
        ellipse2.Margin = new Thickness(20);

        ToolTipService.SetInitialShowDelay(ellipse2, 1000);
        ToolTipService.SetBetweenShowDelay(ellipse2, 2000);
        ToolTipService.SetShowDuration(ellipse2, 7000);
        ToolTipService.SetPlacement(ellipse2, PlacementMode.Right);
        ToolTipService.SetPlacementRectangle(ellipse2, new Rect(50, 0, 0, 0));
        ToolTipService.SetHorizontalOffset(ellipse2, 10.0);
        ToolTipService.SetVerticalOffset(ellipse2, 20.0);
        ToolTipService.SetHasDropShadow(ellipse2, false);
        ToolTipService.SetIsEnabled(ellipse2, true);
        ToolTipService.SetShowOnDisabled(ellipse2, true);

        //ellipse2.AddHandler(ToolTipService.ToolTipOpeningEvent,
        //    new RoutedEventHandler(whenToolTipOpens));
        //ellipse2.AddHandler(ToolTipService.ToolTipClosingEvent,
        //    new RoutedEventHandler(whenToolTipCloses));

        //define tooltip content
        BulletDecorator bdec2 = new BulletDecorator();
        Ellipse littleEllipse2 = new Ellipse();
        littleEllipse2.Height = 10;
        littleEllipse2.Width = 20;
        littleEllipse2.Fill = Brushes.Blue;
        bdec2.Bullet = littleEllipse2;
        TextBlock tipText2 = new TextBlock();
        tipText2.Text = "Uses the ToolTipService class";
        bdec2.Child = tipText2;
        ToolTipService.SetToolTip(ellipse2, bdec2);

        StackPanel stackPanel_1_2 = new StackPanel();
        stackPanel_1_2.Children.Add(ellipse2);

        this.Content = stackPanel_1_2;
    }

    private void MakeToolTip() {
        Button button = new Button {
            Content = "BIG BUTTON",
            Background = Brushes.Tan
        };

        ToolTip toolTip = new ToolTip();
        StackPanel stackPanel = new StackPanel();

        stackPanel.Children.Add(new TextBlock { Text = "Подсказка1" });
        stackPanel.Children.Add(new TextBlock { Text = "Подсказка2" });
        stackPanel.Children.Add(new Button { Content = "Кнопка" });

        toolTip.Content = stackPanel;
        button.ToolTip = toolTip;

        this.Content = button;
    }

    private void whenToolTipOpens(object sender, ToolTipEventArgs e) {
        MessageBox.Show("Сработало событие Opening", "Info");
    }

    private void whenToolTipCloses(object sender, ToolTipEventArgs e) {
        MessageBox.Show("Сработало событие Closing", "Info");
    }
}
