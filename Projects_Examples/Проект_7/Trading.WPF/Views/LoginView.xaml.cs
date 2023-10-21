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

namespace Trading.WPF.Views;


public partial class LoginView : UserControl {

    public static readonly DependencyProperty LoginCommandProperty =
        DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(LoginView), new PropertyMetadata(null));

    public ICommand LoginCommand {
        get => (ICommand)GetValue(LoginCommandProperty);
        set => SetValue(LoginCommandProperty, value);
    }
   
    public LoginView() {
        InitializeComponent();
    }

    private void Login_Click(object sender, RoutedEventArgs e) {
    
        if (LoginCommand != null) {
            string pass = pbPassword.Password;
            LoginCommand.Execute(pass);
        }
    }
}
