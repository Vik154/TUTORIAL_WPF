using Microsoft.EntityFrameworkCore;

namespace ManageDB.Model.Data;

internal class ApplicationContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
    
    public ApplicationContext() {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("\"Data Source=(localdb)\\\\MSSQLLocalDB;Initial Catalog=ManageDB;Integrated Security=True\"");

        //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
    }
}
