using CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Models;

namespace CleanArchitectureBlazor.Core.ApplicationService.Models.Security.User;

public class UserLoginModel : BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }

}
