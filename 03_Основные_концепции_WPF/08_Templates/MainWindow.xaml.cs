using System.Windows;

namespace _08_Templates;

public partial class MainWindow : Window {

    private static ResourceDictionary _resources = new ResourceDictionary();

    public MainWindow() {
        InitializeComponent();

        _resources.Source = new System.Uri("Dictionary1.xaml", System.UriKind.Relative);
        Application.Current.Resources.MergedDictionaries[0] = _resources;
    }
}
