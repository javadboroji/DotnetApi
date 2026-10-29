using System.Net;
using System.Text.Json;
using DotnetApi.Common.Responses;

namespace DotnetApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new ApiResponse<object>(
            false,
            exception.Message
        );

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}