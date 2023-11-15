using Microsoft.AspNetCore.Identity;

namespace UserApi.Models;

public class User : IdentityUser
{
    public DateTime BornDate { get; set; }
    public User() : base() {}
}