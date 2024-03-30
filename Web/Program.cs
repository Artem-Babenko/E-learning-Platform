using Serilog;
using Microsoft.AspNetCore.ResponseCompression;
using BLL.IoCResolver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(
        path: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log-.txt"),
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Cookies").AddCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Name = "AuthenticationCookie";
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/login";
});
builder.Services.AddAuthorization();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
});

builder.Services.AddBLLScopedServices();
builder.Services.AddUnitOfWork();

var app = builder.Build();

app.UseStaticFiles(); 
app.MapControllers();
app.UseRouting();

app.UseSerilogRequestLogging();
app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

