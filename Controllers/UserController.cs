using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(CreateUserDto userDto)
    {
        await _userService.Register(userDto);
        return Ok("User was successfully registered.");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
         var token = await _userService.Login(loginUserDto);
         return Ok(token);
    }
}