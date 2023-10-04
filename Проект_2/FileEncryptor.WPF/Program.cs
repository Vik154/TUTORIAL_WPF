namespace FileEncryptor.WPF;

// Точка входа
internal static class Program {

    [STAThread]
    public static void Main(string[] args) {
        var app = new App();
        app.InitializeComponent();
        app.Run();
    }
}
