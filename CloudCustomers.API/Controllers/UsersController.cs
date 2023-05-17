using CloudCustomers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    //private readonly ILogger<UsersController> _logger;
    public readonly IUserService _userService;


    public UsersController(IUserService userService)
    {
        this._userService = userService;
    }


    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var clients = await _userService.ListUsers();

        if (clients.Any())
            return Ok(clients);
        return NotFound();
    }
}

