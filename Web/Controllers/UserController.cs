using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("users")]
public class UserController : BaseController
{
    private IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userService.GetUsersList();
        return Json(users);
    }
}
