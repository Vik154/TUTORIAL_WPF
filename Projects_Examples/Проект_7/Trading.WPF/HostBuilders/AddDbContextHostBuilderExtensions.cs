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
            string? connectionString = context.Configuration.GetConnectionString("sqlite");

            if (connectionString == null) {
                throw new Exception("Строка подкл");
            }

            // Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);
            Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);

            services.AddDbContext<SimpleTraderDbContext>(configureDbContext);
            services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(configureDbContext));
            //services.AddTransient<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(configureDbContext));
        });

        return host;
    }
}
