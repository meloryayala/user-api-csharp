using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserApi.Data.Dtos;
using UserApi.Models;

namespace UserApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterUser(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded) return Ok("User was successfully registered.");

        throw new ApplicationException("Error when registering the user.");
    }
}