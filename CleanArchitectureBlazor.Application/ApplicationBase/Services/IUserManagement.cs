namespace CleanArchitectureBlazor.Application.ApplicationBase.Services;

public interface IUserManagement
{
    long UserId { get; set; }
    string UserName { get; set; }
    long UserRoleId { get; set; }
    string Rolekey { get; set; }
    string UserIP { get; set; }
}


