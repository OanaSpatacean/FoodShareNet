using Microsoft.AspNetCore.Mvc;

namespace FoodShareNetAPI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
