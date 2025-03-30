namespace BlazorSolution.Infra.Data.SqlServer.Identity.Entities;

public class ApplicationUser : IdentityUser<long>
{
    public ApplicationUser()
    {

    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class ApplicationRole : IdentityRole<long>
{
    public ApplicationRole()
    {

    }
    public string Title { get; set; }
    public bool IsDefault { get; set; }
}

public class ApplicationUserClaim : IdentityUserClaim<long> { }
public class ApplicationUserLogin : IdentityUserLogin<long> { }
public class ApplicationUserRole : IdentityUserRole<long> { }
public class ApplicationUserToken : IdentityUserToken<long> { }
public class ApplicationRoleClaim : IdentityRoleClaim<long> { }