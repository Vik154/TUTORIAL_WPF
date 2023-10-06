using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist;

public class Program {

    [STAThread]
    public static void Main(string[] args) {
        var app = new App();
        app.InitializeComponent();
        app.Run();
    }

    // CreateHostBuilder - это название фиксировано для EF
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices(App.ConfigureServices);
        
}
