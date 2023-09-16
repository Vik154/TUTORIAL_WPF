using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_Resources; 

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();

        // Пример 2 Разница между статическими и динамическими ресурсами
        // this.Resources["ButtonBackground"] = Brushes.Green;
        
        // Пример 3 Поиск ресурсов в коде
        Button button = new Button();

        try {
            // var res1 = FindResource("12345");
            var res2 = button.FindResource("12345");
        }
        catch (Exception ex) {
            Console.WriteLine($"{ex.Message}");
            // Ресурс "12345" не найден.
        }

        var res3 = button.TryFindResource("123");
        var res4 = Resources["123"];
        Console.WriteLine("Всё ок");
    }

    // 1.0 - Программное добаление ресурсов
    private void MakeResources() {

    }
}
