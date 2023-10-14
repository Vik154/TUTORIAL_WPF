using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TaskManager.API.Models;
using TaskManager.API.Models.Data;
using TaskManager.API.Models.Services;
using TaskManager.Common.Models;

namespace TaskManager.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase {

    private readonly ApplicationContext _db;
    private readonly UserService _userService;

    public AccountController(ApplicationContext db) {
        _db = db;
        _userService = new UserService(db);
    }

    [Authorize]
    [HttpGet("info")]
    public IActionResult GetCurrentUserInfo() {
        string? username = HttpContext?.User?.Identity?.Name;

        if (username == null)
            return NotFound("UserName not found!");

        var user = _db.Users.FirstOrDefault(u => u.Email == username);

        if (user == null)
            return NotFound("User Email not found");
        return Ok();
    }

    [HttpPost("token")]
    public IActionResult GetToken() {
        var userData = _userService.GetUserLoginPassFromBasicAuth(Request);
        var login = userData.Item1;
        var pass = userData.Item2;
        var identity = _userService.GetIdentity(login, pass);

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity?.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(
                AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256)
            );            
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new {
            access_token = encodedJwt,
            username = identity?.Name
        };

        return Ok(response);
    }

    [Authorize]
    [HttpPatch("update")]
    public IActionResult UpdateUser([FromBody] UserModel user) {
        if (user is null)
            return BadRequest("\"Не корректный юзер в [Update]");

        string? userName = HttpContext?.User?.Identity?.Name;
        User? userUpdate = _db.Users.FirstOrDefault(x => x.Email == userName);

        if (userUpdate is null)
            return NotFound();

        userUpdate.FirstName = user.FirstName;
        userUpdate.LastName = user.LastName;
        userUpdate.Password = user.Password;
        userUpdate.Phone = user.Phone;
        userUpdate.Photo = user.Photo;

        _db.Users.Update(userUpdate);
        _db.SaveChanges();
        return Ok();
    }
}
