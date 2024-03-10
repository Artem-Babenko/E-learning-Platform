using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Web.Models;
using BLL.Enums;
using BLL.Extensions;

namespace Web.Controllers;

[Route("")]
public class EducationalPlatformController : Controller
{

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        var layoutModel = new LayoutModel();

        string? langFromCookies = HttpContext.Request.Cookies["language"];
        eLanguages enumLanguage = Enum.Parse<eLanguages>(langFromCookies ?? "UK");
        string selectedLanguage = enumLanguage.ToString();

        CultureInfo.CurrentCulture = new CultureInfo(selectedLanguage);
        CultureInfo.CurrentUICulture = new CultureInfo(selectedLanguage);

        layoutModel.Language = enumLanguage;

        ViewBag.LayoutModel = layoutModel;
        return View();
    }
}
