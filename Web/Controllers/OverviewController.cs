using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class OverviewController : BaseController
{
    [HttpGet]
    [Route("")]
    [Route("overview")]
    public IActionResult OverviewPage()
    {
        return View("Views/Platform/Overview.cshtml");
    }
}
