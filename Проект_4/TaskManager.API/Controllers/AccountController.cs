using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models.Data;

namespace TaskManager.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase {

    private readonly ApplicationContext _db;

    public AccountController(ApplicationContext db) => _db = db;

    [HttpGet("info")]
    public IActionResult GetCurrentUserInfo() {
        
    }
}
