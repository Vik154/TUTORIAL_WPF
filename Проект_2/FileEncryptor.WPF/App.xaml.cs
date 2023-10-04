using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FileEncryptor.WPF; 

public partial class App : Application {
    
    internal static void ConfigureServices(HostBuilderContext context, IServiceCollection collection) {
        throw new NotImplementedException();
    }
}
