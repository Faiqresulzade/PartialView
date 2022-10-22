using Microsoft.AspNetCore.Mvc;

namespace front_to_back.Areas.admin.Controllers
{
    [Area("Admin")]
    public class DashboardController :Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
