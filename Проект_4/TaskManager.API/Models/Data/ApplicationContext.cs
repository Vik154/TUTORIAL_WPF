using Microsoft.EntityFrameworkCore;
using TaskManager.Common.Models;

namespace TaskManager.API.Models.Data;

public class ApplicationContext : DbContext {
    public DbSet<User>         Users { get; set; }
    public DbSet<Project>      Projects { get; set; }
    public DbSet<ProjectAdmin> ProjectAdmins { get; set; }
    public DbSet<TaskModel>    Tasks { get; set; }
    public DbSet<Desk>         Desks { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        Database.EnsureCreated();

        if (Users?.Any(u => u.Status == UserStatus.Admin) == false ) {
            Users.Add(new User("Admin", "Adminovich", "admin", "123", UserStatus.Admin));
            SaveChanges();
        }
    }
}
