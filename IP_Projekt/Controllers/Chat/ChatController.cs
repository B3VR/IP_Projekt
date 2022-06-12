using Microsoft.AspNetCore.Mvc;

namespace IP_Projekt.Controllers.Chat
{
    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
}
