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

    // Для теста
    [HttpGet("test")]
    public IActionResult Test() {
        return Ok("Всё ок");
    }

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

    [HttpPatch("{id}/update")]
    public IActionResult UpdateUser(int id, [FromBody] UserModel user) {
        if (user is null)
            return BadRequest("\"Не корректный юзер в [Update]");

        User? userUpdate = _db.Users.FirstOrDefault(x => x.Id == id);

        if (userUpdate is null)
            return NotFound();

        userUpdate.FirstName = user.FirstName;
        userUpdate.LastName = user.LastName;
        userUpdate.Password = user.Password;
        userUpdate.Phone = user.Phone;
        userUpdate.Photo = user.Photo;
        userUpdate.Status = user.Status;
        userUpdate.Email = user.Email;

        _db.Users.Update(userUpdate);
        _db.SaveChanges();
        return Ok();
    }
}
