using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_LeChiCuong_2131200001.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserTable()
        {
            return View();
        }

        public IActionResult BookManagement()
        {
            return View();
        }
    }
}
