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
            await context.Response.WriteAsync($"Error: {ex.Message}");
        }
    }
}
