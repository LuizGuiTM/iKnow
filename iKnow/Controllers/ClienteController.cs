using iKnow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Home()
        {
            return View();
        }
    }
}
