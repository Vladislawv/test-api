using System.Net;
using System.Net.Mime;
using System.Text.Json;
using TestApi.Dto;

namespace TestApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(e, context);
        }
    }

    private async Task HandleExceptionAsync(Exception ex, HttpContext context)
    {
        _logger.LogError(ex.Message);
        
        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorDto = new ErrorDto
        {
            ErrorMessage = ex.Message
        };

        var result = JsonSerializer.Serialize(errorDto, new JsonSerializerOptions(JsonSerializerDefaults.Web));

        await response.WriteAsync(result);
    }
}
