using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlazor.Server.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{

}
