using Microsoft.AspNetCore.Mvc;

namespace FoodShareNetAPI.Controllers
{
    public class CourierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
