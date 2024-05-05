using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class TaskController : BaseController
{
    [HttpGet]
    [Route("tasks")]
    public IActionResult TasksPage()
    {
        return View("Platform/Tasks");
    }
}
