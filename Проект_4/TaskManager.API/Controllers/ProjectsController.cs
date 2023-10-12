using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models;
using TaskManager.API.Models.Data;
using TaskManager.API.Models.Services;
using TaskManager.Common.Models;

namespace TaskManager.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProjectsController : ControllerBase {
    private readonly ApplicationContext _db;
    private readonly UserService _userService;
    private readonly ProjectsService _projectsService;

    public ProjectsController(ApplicationContext db) {
        _db = db;
        _userService = new UserService(db);
        _projectsService = new ProjectsService(db);
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectModel>> Get() { 
        return await _db.Projects.Select(x => x.ToDto()).ToListAsync();
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProjectModel projectModel) {
        if (projectModel != null) {
            var user = _userService.GetUser(HttpContext.User.Identity?.Name ?? "Unknown");
            
            if (user != null) {
                var admin = _db.ProjectAdmins.FirstOrDefault(a => a.UserId == user.Id);
                if (admin == null) {
                    admin = new ProjectAdmin(user);
                    _db.ProjectAdmins.Add(admin);
                }
                projectModel.AdminId = admin.Id;
            }
            
            bool res = _projectsService.Create(projectModel);
            return res ? Ok() : NotFound();
        }
        return BadRequest();
    }

    [HttpPatch]
    public IActionResult Update(int id, [FromBody] ProjectModel projectModel) {
        if (projectModel != null) {

        }
        return BadRequest();
    }

    [HttpDelete]
    public IActionResult Delete(int id) {
        bool res = _projectsService.Delete(id);
        return res ? Ok() : NotFound();
    }

}
