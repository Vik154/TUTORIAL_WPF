using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models.Data;
using TaskManager.API.Models.Services;

namespace TaskManager.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase {

    private readonly ApplicationContext _db;
    private readonly UserService _usersService;
    private readonly TasksService _tasksService;

    public TasksController(ApplicationContext db) {
        _db = db;
        _usersService = new UserService(db);
        _tasksService = new TasksService(db);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Common.Models.TaskModel>>> GetTasksByDesk(int deskId) {
        var result = await _tasksService.GetAll(deskId).ToListAsync();
        return result == null ? NoContent() : Ok(result);
    }

    [HttpGet("user")]
    public async Task<ActionResult<IEnumerable<Common.Models.TaskModel>>> GetTasksForCurrentUser() {
        var user = _usersService.GetUser(HttpContext.User.Identity.Name);
        if (user != null) {
            var result = await _tasksService.GetTasksForUser(user.Id).ToListAsync();
            return result == null ? NoContent() : Ok(result);
        }
        return Unauthorized();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id) {
        var task = _tasksService.Get(id);
        return task == null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Common.Models.TaskModel model) {
        var user = _usersService.GetUser(HttpContext.User.Identity.Name);
        if (user != null) {
            if (model != null) {
                model.CreatorId = user.Id;
                bool result = _tasksService.Create(model);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }
        return Unauthorized();
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] Common.Models.TaskModel model) {
        var user = _usersService.GetUser(HttpContext.User.Identity.Name);
        if (user != null) {
            if (model != null) {
                bool result = _tasksService.Update(id, model);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }
        return Unauthorized();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        bool result = _tasksService.Delete(id);
        return result ? Ok() : NotFound();
    }
}
