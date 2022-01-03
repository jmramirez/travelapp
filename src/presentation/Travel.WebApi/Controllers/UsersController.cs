using Microsoft.AspNetCore.Mvc;
using Travel.Application.Common.Interfaces;
using Travel.Application.Dtos.User;

namespace Travel.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpPost("auth")]
    public IActionResult Authenticate([FromBody] AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        if (response == null)
            return BadRequest(new {message = "Username or password is incorrect"});
        return Ok(response);
    }
}