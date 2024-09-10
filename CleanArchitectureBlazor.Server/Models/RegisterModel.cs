namespace CleanArchitectureBlazor.Server.Models;

public class RegisterModel
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }

}