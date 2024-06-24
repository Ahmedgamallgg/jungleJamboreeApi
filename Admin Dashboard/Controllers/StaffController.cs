using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class StaffController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
