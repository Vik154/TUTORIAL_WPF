namespace TaskManager.Common.Models;


public class ProjectModel : CommonModel {
    public int? AdminId { get; set; }
    public List<int> AllUsersIds { get; set; } = new();
    public List<int> AllDesksIds { get; set; } = new();
    public ProjectStatus Status { get; set; }

    public ProjectModel() { }
    public ProjectModel(string name, string description, ProjectStatus status) {
        Name = name;
        Description = description;
        Status = status;
    }
}
