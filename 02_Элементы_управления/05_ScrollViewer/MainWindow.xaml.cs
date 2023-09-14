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

namespace _05_ScrollViewer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void UpClick(object sender, RoutedEventArgs e) {
            _scroll.LineUp();
        }

        private void DownClick(object sender, RoutedEventArgs e) {
            _scroll.LineDown();
        }

        private void LeftClick(object sender, RoutedEventArgs e) {
            _scroll.LineLeft();
        }

        private void RightClick(object sender, RoutedEventArgs e) {
            _scroll.LineRight();
        }
    }
}
