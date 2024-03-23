using Serilog;
using Microsoft.AspNetCore.ResponseCompression;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Логування Serilog.
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

// Контроллери з представленнями.
builder.Services.AddControllersWithViews();

// Авторизація та аутентифікація.
builder.Services.AddAuthentication("Cookies").AddCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Name = "AuthenticationCookie";
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/login";
});
builder.Services.AddAuthorization();

// Стиснення відповіді.
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
});

// Сервіси шару бізнес логіки.
builder.Services.AddBLLScopedServices();

var app = builder.Build();

app.UseStaticFiles(); 
app.MapControllers();
app.UseRouting();

app.UseSerilogRequestLogging();
app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

