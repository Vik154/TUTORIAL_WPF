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
        this.Resources["ButtonBackground"] = Brushes.Green;
    }

    // 1.0 - Программное добаление ресурсов
    private void MakeResources() {

    }
}
