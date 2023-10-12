using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TaskManager.API.Models;
using TaskManager.API.Models.Data;
using TaskManager.API.Models.Services;

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
}
