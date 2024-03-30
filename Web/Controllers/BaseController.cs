using Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using Web.Models;

namespace Web.Controllers;

public abstract class BaseController : Controller
{
    public LayoutModel LayoutModel { get; private set; } = null!;

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);

        var layoutModel = new LayoutModel();

        string? langFromCookies = HttpContext.Request.Cookies["language"];
        eLanguages enumLanguage = Enum.Parse<eLanguages>(langFromCookies ?? "UK");
        string selectedLanguage = enumLanguage.ToString();

        CultureInfo.CurrentCulture = new CultureInfo(selectedLanguage);
        CultureInfo.CurrentUICulture = new CultureInfo(selectedLanguage);

        layoutModel.Language = enumLanguage;

        ViewBag.LayoutModel = layoutModel;
        LayoutModel = layoutModel;
    }
}
