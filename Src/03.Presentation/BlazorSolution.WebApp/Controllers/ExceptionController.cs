using BlazorSolution.Core.Application.Common.Exceptions;
using BlazorSolution.WebApp.Common.BaseApi;
using BlazorSolution.Core.Domain.Common.Exceptions;
using BlazorSolution.Infra.Data.SqlServer.Common.Exceptions;
using BlazorSolution.WebApp.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ApplicationException = BlazorSolution.Core.Application.Common.Exceptions.ApplicationException;
using SystemException = BlazorSolution.Core.Application.Common.Exceptions.SystemException;

namespace BlazorSolution.WebApp.Controllers;

public enum ExceptionId
{
    Domain,
    Application,
    Infrastructure,
    EndPoint,
    Access,
}

public class ExceptionController : BaseContorller
{
    [HttpGet("GetException/{exceptionId}")]
    public IActionResult DomainException(ExceptionId exceptionId)
    {
        try
        {
            switch (exceptionId)
            {
                case ExceptionId.Domain:
                    throw new DomainException("Domain Entity Or Aggregate Logic Error");
                case ExceptionId.Application:
                    throw new ApplicationException("Application Service Handler Logic Error");
                case ExceptionId.Infrastructure:
                    throw new InfraException("Infrastructure Service Logic Error");
                case ExceptionId.EndPoint:
                    throw new EndPointException("Api Request Logic Error");
                case ExceptionId.Access:
                    throw new AccessDenideException("You Have Not Access !!!");
                default:
                    throw new SystemException("Server is busy !!!");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}
