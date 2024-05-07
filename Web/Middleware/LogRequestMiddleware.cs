using Newtonsoft.Json;
using Serilog;
using System.Diagnostics;

namespace Web.Middleware;

internal class LogRequestMiddleware
{
    private readonly RequestDelegate _next;

    public LogRequestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();

        LogRequest(context.Request);

        await _next(context);

        watch.Stop();
        var executingTimeInMs = watch.ElapsedMilliseconds;

        LogResponse(context.Response, executingTimeInMs);
    }

    private void LogRequest(HttpRequest request)
    {
        Log.Information("----------------------------------------------");
        Log.Information("Request");
        Log.Information($"- Path: {request.Path}");
        Log.Information($"- Method: {request.Method}");

        using var st = new StreamReader(request.Body);
        var bodyString = st.ReadToEndAsync().Result;
        if(!string.IsNullOrEmpty(bodyString))
            Log.Information($"- Body: {bodyString}");

        if (request.ContentType == "application/x-www-form-urlencoded" 
            || request.ContentType == "multipart/form-data")
        {
            var fromInJson = JsonConvert.SerializeObject(request.Form);
            Log.Information($"- Form: {fromInJson}");
        }
    }

    private void LogResponse(HttpResponse response, long executingTimeInMs)
    {
        Log.Information("Response");
        Log.Information($"- StatusCode: {response.StatusCode}");
        Log.Information($"- ContentType: {response.ContentType}");
        Log.Information($"- ContentLength: {response.ContentLength}");
        Log.Information($"Executing time: {executingTimeInMs} ms");
    }
}
