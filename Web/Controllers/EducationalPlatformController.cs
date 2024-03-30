using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("")]
[Route("platform")]
public class EducationalPlatformController : BaseController
{
    [HttpGet]
    [Route("")]
    [Route("overview")]
    public IActionResult GetOverviewPage()
    {
        return View("Overview");
    }

    [HttpGet]
    [Route("courses")]
    public IActionResult GetCoursesPage()
    {
        return View("Courses");
    }

    [HttpGet]
    [Route("profile")]
    public IActionResult GetProfilePage()
    {
        return View("Profile");
    }

    [HttpGet]
    [Route("timetable")]
    public IActionResult GetTimetablePage()
    {
        return View("Timetable");
    }

    [HttpGet]
    [Route("tasks")]
    public IActionResult GetTasksPage()
    {
        return View("Tasks");
    }
}
