using BlazorSolution.Core.Application.Common.Exceptions;
using BlazorSolution.Core.Domain.Common.Exceptions;
using BlazorSolution.Infra.Data.SqlServer.Common.Exceptions;
using BlazorSolution.WebApp.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ApplicationException = BlazorSolution.Core.Application.Common.Exceptions.ApplicationException;

namespace BlazorSolution.WebApp.Middlewares.ExceptionHandler;

public class ApiExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ApiExceptionMiddleware(
        RequestDelegate next,
        ILogger<ApiExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if (context.Response.HasStarted)
            {
                _logger.LogWarning("Response has already started, cannot modify error response");
                throw;
            }

            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        try
        {
            var (statusCode, errorDetails) = GetErrorDetails(ex);
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            LogException(ex, statusCode);

            var response = BuildErrorResponse(context, ex, statusCode, errorDetails);
            await WriteResponseAsync(context, response);
        }
        catch (Exception handlerEx)
        {
            _logger.LogError(handlerEx, "An error occurred while handling the exception");
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }

    private (HttpStatusCode statusCode, string errorDetails) GetErrorDetails(Exception ex)
    {
        var statusCode = ex switch
        {
            DomainException or ApplicationException or InfraException or EndPointException
                => HttpStatusCode.InternalServerError,
            BadRequestException => HttpStatusCode.BadRequest,
            NotFoundException => HttpStatusCode.NotFound,
            ValidationException => HttpStatusCode.UnprocessableEntity,
            AccessDenideException => HttpStatusCode.Unauthorized,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError
        };

        var errorDetails = ex switch
        {
            DomainException => ex.Message ?? "Domain validation error",
            ApplicationException => ex.Message ?? "Application error",
            InfraException => ex.Message ?? "Infrastructure error",
            EndPointException => ex.Message ?? "API error",
            AccessDenideException => ex.Message ?? "You Can't Call Service",
            _ => ex.Message ?? "An unexpected error occurred"
        };

        return (statusCode, errorDetails);
    }

    private void LogException(Exception ex, HttpStatusCode statusCode)
    {
        var logLevel = statusCode >= HttpStatusCode.InternalServerError
            ? LogLevel.Error
            : LogLevel.Warning;

        _logger.Log(
            logLevel,
            ex,
            "Exception of type {ExceptionType} occurred: {Message}",
            ex.GetType().Name,
            ex.Message);
    }

    private ApiErrorResponse BuildErrorResponse(
        HttpContext context,
        Exception ex,
        HttpStatusCode statusCode,
        string errorDetails)
    {
        return _env.IsDevelopment()
            ? new ApiErrorResponse(
                statusCode,
                errorDetails,
                ex.StackTrace,
                context.TraceIdentifier)
            : new ApiErrorResponse(statusCode, errorDetails);
    }

    private async Task WriteResponseAsync(HttpContext context, ApiErrorResponse response)
    {
        var json = JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = _env.IsDevelopment()
            });

        await context.Response.WriteAsync(json);
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiExceptionMiddleware>();
    }
}
