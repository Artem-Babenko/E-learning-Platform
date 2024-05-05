using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CalendarController : BaseController
{
    [HttpGet]
    [Route("calendar")]
    public IActionResult CalendarPage()
    {
        return View("Views/Platform/Calendar.cshtml");
    }
}
