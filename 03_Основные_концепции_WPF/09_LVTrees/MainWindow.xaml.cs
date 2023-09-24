using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Windows.Markup;
using System.Text;

namespace _09_LVTrees;

public class TypeComparer : IComparer<Type> {

    public int Compare(Type? x, Type? y) {
        if (x != null && y != null)
            return x.Name.CompareTo(y.Name);
        return 0;
    }
}

public partial class MainWindow : Window {
    
    public MainWindow() {
        InitializeComponent();
    }

    #region TAB_2 - Просмотр разметки

    private void _listBaseElements_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
        try {
            // Get the selected type.
            Type type = (Type)_listBaseElements.SelectedItem;

            // Instantiate the type.
            ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
            Control control = (Control)info.Invoke(null);

            Window win = control as Window;
            if (win != null) {
                // Create the window (but keep it minimized).
                win.WindowState = System.Windows.WindowState.Minimized;
                win.ShowInTaskbar = false;
                win.Show();
            }
            else {
                // Add it to the grid (but keep it hidden).
                control.Visibility = Visibility.Collapsed;
                grid.Children.Add(control);
            }

            // Get the template.
            ControlTemplate template = control.Template;

            // Get the XAML for the template.
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            XamlWriter.Save(template, writer);

            // Display the template.
            _textInfo.Text = sb.ToString();

            // Remove the control from the grid.
            if (win != null) {
                win.Close();
            }
            else {
                grid.Children.Remove(control);
            }
        }
        catch (Exception err) {
            _textInfo.Text = "<< Error generating template: " + err.Message + ">>";
        }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
        Type typeControl = typeof(Control);
        List<Type> myTypes = new List<Type>();

        // Ищем все типы в сборке
        Assembly? assembly = Assembly.GetAssembly(typeof(Control));

        if (assembly != null) {
            foreach (Type type in assembly.GetTypes()) {
                if (type.IsSubclassOf(typeControl) && !type.IsAbstract && type.IsPublic) {
                    myTypes.Add(type);
                }

                // отсортируем список
                myTypes.Sort(new TypeComparer());

                _listBaseElements.ItemsSource = myTypes;
                _listBaseElements.DisplayMemberPath = "Name";
            }
        }
        else {
            MessageBox.Show("Null прилетел из - GetAssembly()");
        }
    }
    #endregion


    #region TAB_1 - Обход логического и визуального деревьев
    // Обход логического дерева
    private void logicBtn_Click(object sender, RoutedEventArgs e) {
        PrintLogicalTree(0, this);
    }

    // Обход визуального дерева
    private void visualBtn_Click(object sender, RoutedEventArgs e) {
        PrintVisualTree(0, this);
    }

    // Обход логического дерева
    private void PrintLogicalTree(int depth, object obj) {
        txt.Text += new string(' ', depth * 4) + $"<{obj.GetType().Name}>\n";

        if (!(obj is DependencyObject)) 
            return;

        foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
            PrintLogicalTree(depth + 1, child);
    }

    // Обход визуального дерева
    private void PrintVisualTree(int depth, object obj) {

        txt.Text += new string(' ', depth * 4) + $"<{obj.GetType().Name}>\n";

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
            PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj as DependencyObject, i));
    }

    private void ClearBtn_Click(object sender, RoutedEventArgs e) {
        txt.Text = string.Empty;
    }
    #endregion
}
