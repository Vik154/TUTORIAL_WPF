using Microsoft.Extensions.Hosting;

namespace FileEncryptor.WPF;

// Точка входа
internal static class Program {

    [STAThread]
    public static void Main(string[] args) {
        var app = new App();
        app.InitializeComponent();
        app.Run();
    }

    // Построитель хоста
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices);
}
