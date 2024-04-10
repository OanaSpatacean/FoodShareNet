using Microsoft.AspNetCore.Mvc;

namespace FoodShareNetAPI.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
