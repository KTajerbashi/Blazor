using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBlazor.AppApi.BaseAppApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{

}


[Authorize]
public abstract class AuthorizeController : BaseController
{

}