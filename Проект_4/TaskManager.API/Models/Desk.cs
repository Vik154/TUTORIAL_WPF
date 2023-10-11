using TaskManager.API.Models.Interfaces;

namespace TaskManager.API.Models;

public class Desk : CommonObject {
    public int Id { get; set; }
    public bool IsPrivate { get; set; }
    public string? Columns { get; set; }
    public User? Admin { get; set; }
    public int AdminId { get; set; }
    public Project? Project { get; set; }
    public int ProjectId { get; set; }
    public List<TaskModel> Tasks { get; set; } = new();
}
