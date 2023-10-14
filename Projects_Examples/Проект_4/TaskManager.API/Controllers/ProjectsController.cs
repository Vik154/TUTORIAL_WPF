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
    public async Task<IEnumerable<CommonModel>> Get() {
        var user = _userService.GetUser(HttpContext.User.Identity?.Name ?? "Unknown");

        if (user?.Status == UserStatus.Admin)
            return await _projectsService.GetAll().ToListAsync();
        else {
            return await _projectsService.GetByUserId(user.Id);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id) {
        var project = _projectsService.Get(id);
        return project == null ? NoContent() : Ok(project);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProjectModel projectModel) {
        if (projectModel != null) {
            var user = _userService.GetUser(HttpContext.User.Identity?.Name ?? "Unknown");
            
            if (user != null) {
                if (user.Status == UserStatus.Admin ||
                    user.Status == UserStatus.Editor) {

                    var admin = _db.ProjectAdmins.FirstOrDefault(a => a.UserId == user.Id);
                    if (admin == null) {
                        admin = new ProjectAdmin(user);
                        _db.ProjectAdmins.Add(admin);
                        _db.SaveChanges();
                    }
                    projectModel.AdminId = admin.Id;

                    bool res = _projectsService.Create(projectModel);
                    return res ? Ok() : NotFound();
                }
            }
            return Unauthorized();
        }
        return BadRequest();
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] ProjectModel projectModel) {
        if (projectModel != null) {
            var user = _userService.GetUser(HttpContext.User.Identity?.Name ?? "Unknown");
            
            if (user != null) {
                if (user.Status == UserStatus.Admin ||
                    user.Status == UserStatus.Editor) 
                {
                    bool res = _projectsService.Update(id, projectModel);
                    return res ? Ok() : NotFound();
                }
            }
            return Unauthorized();
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        bool res = _projectsService.Delete(id);
        return res ? Ok() : NotFound();
    }

    [HttpPatch("{id}/users")]
    public IActionResult AddUsersToProject(int id, [FromBody] List<int> usersIds) {
        if (usersIds != null) {
            var user = _userService.GetUser(HttpContext.User.Identity?.Name ?? "Unknown");

            if (user != null) {
                if (user.Status == UserStatus.Admin ||
                    user.Status == UserStatus.Editor) 
                {
                    _projectsService.AddUsersToProject(id, usersIds);
                    return Ok();
                }
                return Unauthorized();
            }
        }
        return BadRequest();
    }

    [HttpPatch("{id}/users/remove")]
    public IActionResult RemoveUsersFromProject(int id, [FromBody] List<int> usersIds) {
        if (usersIds != null) {
            var user = _userService.GetUser(HttpContext.User.Identity.Name);
            if (user != null) {
                if (user.Status == UserStatus.Admin || user.Status == UserStatus.Editor) {
                    _projectsService.RemoveUsersFromProject(id, usersIds);
                    return Ok();
                }
                return Unauthorized();
            }
        }
        return BadRequest();
    }
}
