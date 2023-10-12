using TaskManager.API.Models.Data;
using TaskManager.API.Models.Interfaces;

namespace TaskManager.API.Models.Services;


public class TasksService : AbstractionService, ICommonService<Common.Models.TaskModel> {
    private readonly ApplicationContext _db;

    public TasksService(ApplicationContext db) {
        _db = db;
    }
    public bool Create(Common.Models.TaskModel model) {
        bool result = DoAction(delegate ()
        {
            TaskModel newTask = new TaskModel(model);
            _db.Tasks.Add(newTask);
            _db.SaveChanges();
        });
        return result;
    }

    public bool Delete(int id) {
        bool result = DoAction(delegate ()
        {
            TaskModel task = _db.Tasks.FirstOrDefault(t => t.Id == id);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        });
        return result;
    }

    public Common.Models.TaskModel Get(int id) {
        TaskModel task = _db.Tasks.FirstOrDefault(t => t.Id == id);
        return task?.ToDto();
    }

    public IQueryable<Common.Models.TaskModel> GetTasksForUser(int userId) {
        return _db.Tasks.Where(t => t.CreatorId == userId || t.ExecutorId == userId).Select(t => t.ToShortDto());
    }

    public bool Update(int id, Common.Models.TaskModel model) {
        bool result = DoAction(delegate ()
        {
            TaskModel task = _db.Tasks.FirstOrDefault(t => t.Id == id);

            task.Name = model.Name;
            task.Description = model.Description;
            task.Photo = model.Photo;
            task.StartDate = model.CreationDate;
            task.EndDate = model.EndDate;
            task.File = model.File;
            task.Column = model.Column;
            task.ExecutorId = model.ExecutorId;

            _db.Tasks.Update(task);
            _db.SaveChanges();
        });
        return result;
    }

    public IQueryable<Common.Models.TaskModel> GetAll(int deskId) {
        return _db.Tasks.Where(t => t.DeskId == deskId).Select(t => t.ToShortDto());
    }
}
