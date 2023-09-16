using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _01_Resources;

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
        // MakeResources();

        // AddHandler(Button.ClickEvent, new RoutedEventHandler(TestResources));


        // Пример 2 Разница между статическими и динамическими ресурсами
        // this.Resources["ButtonBackground"] = Brushes.Green;

        // Пример 3 Поиск ресурсов в коде
        //Button button = new Button();

        //try {
        //    // var res1 = FindResource("12345");
        //    var res2 = button.FindResource("12345");
        //}
        //catch (Exception ex) {
        //    Console.WriteLine($"{ex.Message}");
        //    // Ресурс "12345" не найден.
        //}

        //var res3 = button.TryFindResource("123");
        //var res4 = Resources["123"];
        //Console.WriteLine("Всё ок");

        //if (TryFindResource("Bla-Bla-Bla") != null)
        //    Console.WriteLine("Ресурс найден");
        //else 
        //    Console.WriteLine("Такого ресурса нет");

        //if (TryFindResource("AliceBlue") != null)
        //    Console.WriteLine("Ресурс найден");
        //else
        //    Console.WriteLine("Такого ресурса нет");

    }

    // 1.0 - Программное добаление ресурсов
    private void MakeResources() {

        StackPanel stackPanel = new StackPanel();
        Button button1 = new Button { Content = "Кнопка 1" };
        Button button2 = new Button { Content = "Кнопка 2" };
        Button button3 = new Button { Content = "Кнопка 3" };

        stackPanel.Children.Add(button1);
        stackPanel.Children.Add(button2);
        stackPanel.Children.Add(button3);

        // добавление ресурса в словарь ресурсов окна
        this.Resources.Add("MyButtonBackground", Brushes.Aquamarine);
        this.Resources.Add("MyFontSize", 18d);
        this.Resources.Add("MyFontWeight", FontWeights.Bold);
        this.Resources.Add("MyWidth", 120d);
        this.Resources.Add("MyThickness", new Thickness(10));

        /* Установка статических ресурсов StaticResource
         * StaticResource и DynamicResource - являются расширениями разметки, из-за этого 
         * эквивалентный код поиска и применения ресурса на C# не вполне очевиден.
         * Чтобы получить поведение, эквивалентное StaticResource, 
         * необходимо записать в свойство элемента результат вызова метода FindResource 
         * (унаследованного от класса FrameworkElement или FrimeworkContentElement).
         * 
         * Таким образом, следующее объявление элемента Button похожее на:
         * <Button Background="{StaticResource MyButtonBackground}"/>
         */
        button1.Background = (Brush)TryFindResource("MyButtonBackground");
        button1.FontSize = (double)TryFindResource("MyFontSize");
        button1.FontWeight = (FontWeight)TryFindResource("MyFontWeight");
        button1.Width = (double)TryFindResource("MyWidth");
        button1.Margin = (Thickness)TryFindResource("MyThickness");

        // Установка динамических ресурсов DynamicResource
        button2.SetResourceReference(Button.BackgroundProperty, "MyButtonBackground");
        button2.SetResourceReference(Button.FontSizeProperty, "MyFontSize");
        button2.SetResourceReference(Button.FontWeightProperty, "MyFontWeight");
        button2.SetResourceReference(Button.WidthProperty, "MyWidth");
        button2.SetResourceReference(Button.MarginProperty, "MyThickness");

        // Установка статических ресурсов StaticResource
        button3.Background = (Brush)this.Resources["MyButtonBackground"];
        button3.FontSize = (double)this.Resources["MyFontSize"];
        button3.FontWeight = (FontWeight)this.Resources["MyFontWeight"];
        button3.Width = (double)this.Resources["MyWidth"];
        button3.Margin = (Thickness)this.Resources["MyThickness"];

        this.Content = stackPanel;
    }

    // 
    private void TestResources(object sender, RoutedEventArgs e) {

        StackPanel tmp = this.Content as StackPanel;

        foreach (Button bt in tmp.Children) {
            bt.Background = Brushes.Green;
        }
    }
}
