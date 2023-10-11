using TaskManager.API.Models.Interfaces;

namespace TaskManager.API.Models;

public class Project : CommonObject {
    public int Id { get; set; }
    public int? AdminId { get; set; }
    public ProjectAdmin? Admin { get; set; }
    public List<User> AllUsers { get; set; } = new();
    public List<Desk> AllDesks { get; set; } = new();
    public ProjectStatus Status { get; set; }
}
