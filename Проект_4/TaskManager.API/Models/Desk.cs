using Newtonsoft.Json;
using TaskManager.API.Models.Interfaces;
using TaskManager.Common.Models;

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

    public Desk() { }

    public Desk(DeskModel deskModel) : base(deskModel) {
        Id = deskModel.Id;
        AdminId = deskModel.AdminId;
        IsPrivate = deskModel.IsPrivate;
        AdminId = deskModel.AdminId;
        ProjectId = deskModel.ProjectId;
        Photo = deskModel.Photo;

        if (deskModel.Columns.Any())
            Columns = JsonConvert.SerializeObject(deskModel.Columns);
    }

    public DeskModel ToDto() {
        return new DeskModel() {
            Id = Id,
            Name = Name,
            Description = Description,
            CreationDate = CreationDate,
            Photo = Photo,
            AdminId = AdminId,
            IsPrivate = IsPrivate,
            Columns = JsonConvert.DeserializeObject<string[]>(Columns),
            ProjectId = ProjectId
        };
    }
    public CommonModel ToShortDto() {
        return new CommonModel() {
            Id = Id,
            Name = Name,
            Description = Description,
            CreationDate = CreationDate,
            Photo = Photo,
        };
    }
}
