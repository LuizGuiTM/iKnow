using iKnow.Models;
using Microsoft.AspNetCore.Mvc;

namespace iKnow.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View(new ClienteViewModel());
        }
    }
}
