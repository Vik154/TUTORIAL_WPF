using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trading.EntityFramework;

namespace Trading.WPF.HostBuilders;

public static class AddDbContextHostBuilderExtensions {
    public static IHostBuilder AddDbContext(this IHostBuilder host) {
        host.ConfigureServices((context, services) =>
        {
            string connectionString = context.Configuration.GetConnectionString("sqlite");
            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

            services.AddDbContext<SimpleTraderDbContext>(configureDbContext);
            services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(configureDbContext));
        });

        return host;
    }
}
