using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class EducationController : BaseController
{
    [HttpGet]
    [Route("education")]
    public IActionResult EducationPage()
    {
        return View("Platform/Education");
    }
}
