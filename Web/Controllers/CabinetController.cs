using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CabinetController : BaseController
{
    private IUserService userService;

    public CabinetController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    [Route("cabinet")]
    public IActionResult CabinetPage()
    {
        return View("Platform/Cabinet");
    }

    public async Task<IActionResult> GetUsers()
    {
        var users = await userService.GetUsersList();
        return Json(users);
    }
}
