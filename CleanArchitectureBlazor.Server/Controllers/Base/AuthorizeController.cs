using Microsoft.AspNetCore.Authorization;

namespace CleanArchitectureBlazor.Server.Controllers.Base;

[Authorize]
public abstract class AuthorizeController : BaseController
{

}