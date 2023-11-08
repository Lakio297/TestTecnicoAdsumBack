using Microsoft.AspNetCore.Mvc;

namespace TestTecnicoAdsum.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
