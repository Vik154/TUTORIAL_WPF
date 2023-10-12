using TaskManager.API.Models.Interfaces;

namespace TaskManager.API.Models;

public class TaskModel : CommonObject {
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public byte[]? File { get; set; }
    public int DeskId { get; set; }
    public Desk? Desk { get; set; }
    public string? Column { get; set; }
    public int? CreatorId {  get; set; }
    public User? Creator {  get; set; }
    public int? ExecutorId { get; set; }

    public TaskModel() { }

    public TaskModel(Common.Models.TaskModel taskModel) : base(taskModel) {
        Id = taskModel.Id;
        StartDate = taskModel.CreationDate;
        EndDate = taskModel.EndDate;
        File = taskModel.File;
        DeskId = taskModel.DeskId;
        Column = taskModel.Column;
        CreatorId = taskModel.CreatorId;
        ExecutorId = taskModel.ExecutorId;
    }

    public Common.Models.TaskModel ToDto() {
        return new Common.Models.TaskModel() {
            Id = Id,
            Name = Name,
            Description = Description,
            CreationDate = CreationDate,
            Photo = Photo,
            StartDate = CreationDate,
            EndDate = EndDate,
            File = File,
            DeskId = DeskId,
            Column = Column,
            CreatorId = CreatorId,
            ExecutorId = ExecutorId
        };
    }

    public Common.Models.TaskModel ToShortDto() {
        return new Common.Models.TaskModel() {
            Id = Id,
            Name = Name,
            Description = Description,
            CreationDate = CreationDate,
            StartDate = CreationDate,
            EndDate = EndDate,
            DeskId = DeskId,
            Column = Column,
            CreatorId = CreatorId,
            ExecutorId = ExecutorId
        };
    }
}
