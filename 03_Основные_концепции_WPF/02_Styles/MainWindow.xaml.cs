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

namespace _02_Styles {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
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
}
