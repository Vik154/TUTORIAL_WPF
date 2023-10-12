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
[Authorize(Roles = "admin")]
public class UsersController : ControllerBase {

    private readonly ApplicationContext _db;
    private readonly UserService _userService;

    // Ctor
    public UsersController(ApplicationContext db) {
        _db = db;
        _userService = new UserService(db);
    }

    // Для теста
    [HttpGet("test")]
    [AllowAnonymous]
    public IActionResult TestApi() {
        return Ok($"Сервер запущен {DateTime.Now}");
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserModel user) {
        if (user is null)
            return BadRequest("Не корректный юзер");

        bool result = _userService.Create(user);
        return result ? Ok() : NotFound();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UserModel user) {
        if (user is null)
            return BadRequest("\"Не корректный юзер в [Update]");

        bool result = _userService.Update(id, user);
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id) {
        bool result = _userService.Delete(id);
        return result ? Ok() : NotFound();
    }

    //[HttpGet]
    //public IEnumerable<UserModel> GetUsers() {
    //    return _db.Users.Select(u => u.ToDto());
    //}

    [HttpGet]
    public async Task<IEnumerable<UserModel>> GetUsersAsync() {
        return await _db.Users.Select(u => u.ToDto()).ToListAsync();
    }

    [HttpPost("all")]
    public async Task<IActionResult> CreateMultipleUsersAsync(
        [FromBody] List<UserModel> userModels) 
    {
        if (userModels != null && userModels.Count > 0) {
            bool result = _userService.CreateMultipleUsers(userModels);
            return result ? Ok() : NotFound();
        }
        return BadRequest();
    }
}
