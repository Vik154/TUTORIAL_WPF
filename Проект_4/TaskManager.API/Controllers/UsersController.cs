using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
using TaskManager.API.Models.Data;
using TaskManager.Common.Models;

namespace TaskManager.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase {

    private readonly ApplicationContext _db;

    // Ctor
    public UsersController(ApplicationContext db) => _db = db;

    [HttpPost("create")]
    public IActionResult CreateUser([FromBody] UserModel user) {
        if (user is null)
            return BadRequest("Не корректный юзер");

        User newUser = new User(user.FirstName, user.LastName, user.Email,
            user.Password, user.Status, user.Phone, user.Photo);
        _db.Users.Add(newUser);
        _db.SaveChanges();
        return Ok();
    }
}
