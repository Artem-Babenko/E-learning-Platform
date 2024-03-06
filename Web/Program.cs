
using Serilog;
using Microsoft.AspNetCore.ResponseCompression;
using BLL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Логування Serilog.
builder.Services.AddLogging();
builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration); //!!! Налаштувати логування
});

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

app.UseSerilogRequestLogging();
app.UseResponseCompression();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

