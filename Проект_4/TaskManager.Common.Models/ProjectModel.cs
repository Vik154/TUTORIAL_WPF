namespace TaskManager.Common.Models;


public class ProjectModel : CommonModel {
    public int? AdminId { get; set; }    
    public List<UserModel> AllUsers { get; set; } = new();
    public List<DeskModel> AllDesks { get; set; } = new();
    public ProjectStatus Status { get; set; }
}
