using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models.Data;

namespace TaskManager.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase {

    private readonly ApplicationContext _db;

    // Ctor
    public UsersController(ApplicationContext db) => _db = db;

}
