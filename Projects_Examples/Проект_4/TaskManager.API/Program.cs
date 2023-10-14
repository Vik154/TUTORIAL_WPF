using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using TaskManager.API.Models;
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

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters {

                        // Указывает будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,

                        // Строка представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,

                        // Будет ли валидироваться потребитель токена
                        ValidateAudience = true,

                        // Установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,

                        // Будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // Установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                        // Валидация ключа безопасности
                        ValidateIssuerSigningKey = true
                    };
                });

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
