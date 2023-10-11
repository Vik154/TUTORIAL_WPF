using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskManager.API.Models.Data;

namespace TaskManager.API {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? connection = builder.Configuration.GetConnectionString("Default");

            if (string.IsNullOrEmpty(connection))
                Debug.WriteLine("Строка подключения не валидная, проверь");

            builder.Services.AddDbContext<ApplicationContext>(op => 
                op.UseSqlServer(connection));

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
