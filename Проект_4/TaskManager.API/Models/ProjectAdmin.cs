namespace TaskManager.API.Models;

public class ProjectAdmin {
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Project> Projects { get; set; } = new();
    
    public ProjectAdmin(User user) {
        User = user;
        UserId = user.Id;
    }
    public ProjectAdmin() { }
}
