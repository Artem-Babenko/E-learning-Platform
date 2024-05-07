using Serilog;

namespace Web.Middleware;

internal class ErrorHandlerMiddleware 
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
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
            Log.Error($"{ex.Message} | {ex.StackTrace}");
            await context.Response.WriteAsync($"Error: {ex.Message}");
        }
    }
}
