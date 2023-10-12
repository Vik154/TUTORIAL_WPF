using TaskManager.API.Models.Data;
using TaskManager.API.Models.Interfaces;
using TaskManager.Common.Models;

namespace TaskManager.API.Models.Services;

public class ProjectsService : AbstractionService, ICommonService<ProjectModel> {
    private readonly ApplicationContext _db;

    public ProjectsService(ApplicationContext db) {
        _db = db;
    }

    public bool Create(ProjectModel model) {
        bool result = DoAction(delegate () {
            Project project = new Project(model);
            _db.Projects.Add(project);
            _db.SaveChanges();
        });
        return result;
    }

    public bool Delete(int id) {
        bool result = DoAction(delegate () {
            Project? project = _db.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                throw new ArgumentException("Project not found");
            _db.Projects.Remove(project);
            _db.SaveChanges();
        });
        return result;
    }

    public bool Update(int id, ProjectModel model) {
        bool result = DoAction(delegate () {
            Project? project = _db.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                throw new ArgumentException("Project not found");
            project.Name = model.Name;
            project.Description = model.Description;
            project.Status = model.Status;
            project.Photo = model.Photo;
            project.AdminId = model.AdminId;
            _db.Projects.Update(project);
            _db.SaveChanges();
        });
        return result;
    }
}
