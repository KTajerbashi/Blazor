using BlazorSolution.Core.Application.Common;

namespace BlazorSolution.Core.Application.Users.Models;

public class UserProfileDTO : BaseDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
