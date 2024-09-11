using CleanArchitectureBlazor.Application.ApplicationBase.Model;

namespace CleanArchitectureBlazor.Application.Models.Security.User;

public class UserLoginModel : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }

}
