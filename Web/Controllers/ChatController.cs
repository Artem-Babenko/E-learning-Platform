using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ChatController : BaseController
{
    [HttpGet]
    [Route("chat")]
    public IActionResult ChatPage()
    {
        return View("Views/Platform/Chat.cshtml");
    }
}
