using CleanArchitectureBlazor.Core.Domains.Security;
using CleanArchitectureBlazor.Infrastructure.ApplicationContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitectureBlazor.Server.Extensions.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        => services.AddIdentity();

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserEntity, RoleEntity>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<DbContextApplication>();
        return services;
    }

    private static IServiceCollection AddJWTIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        return services;
    }

    public static async Task UseCreateSeed(this WebApplication app)
    {

        var roleManager = app.Services.GetRequiredService<RoleManager<RoleEntity>>();
        var userManager = app.Services.GetRequiredService<UserManager<UserEntity>>();

        string[] roleNames = { "Admin" };
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new RoleEntity(roleName));
            }
        }

        // Seed an admin user
        var adminUser = new UserEntity { UserName = "admin", Email = "admin@myapp.com" };
        string adminPassword = "Admin@1234";
        var user = await userManager.FindByEmailAsync("admin@mail.com");

        if (user == null)
        {
            var createUser = await userManager.CreateAsync(adminUser, adminPassword);
            if (createUser.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }

}
