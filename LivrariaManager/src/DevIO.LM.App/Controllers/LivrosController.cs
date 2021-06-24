using Microsoft.AspNetCore.Mvc;

namespace DevIO.LM.App.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
