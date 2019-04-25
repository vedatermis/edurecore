using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}