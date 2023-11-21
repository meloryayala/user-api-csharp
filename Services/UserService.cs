using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserApi.Data.Dtos;
using UserApi.Models;

namespace UserApi.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Register(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException(result.Errors.ToString());
        }
    }
}