using Microsoft.AspNetCore.Mvc;

namespace FoodShareNetAPI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
