using Microsoft.AspNetCore.Mvc;
using Texter.Models;

namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}