using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.VisualBasic.CompilerServices;

namespace UserApi.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }
    
    [Required] 
    public DateTime BornDate { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}