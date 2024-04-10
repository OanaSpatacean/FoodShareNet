using Microsoft.AspNetCore.Mvc;

namespace FoodShareNetAPI.Properties
{
    public class DonationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
