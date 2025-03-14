using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitectureBlazor.WebApp.Common.BaseApi;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseContorller : Controller
{
    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    {
        return base.Ok(new
        {
            Data = value,
            Success = true
        });
    }
}

public abstract class AuthController : BaseContorller
{

}
