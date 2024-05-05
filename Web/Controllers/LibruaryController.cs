using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class LibruaryController : BaseController
{
    [HttpGet]
    [Route("libruary")]
    public IActionResult LibruaryPage()
    {
        return View("Platform/Libruary");
    }
}
