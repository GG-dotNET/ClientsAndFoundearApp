using AspNetCoreCRUD.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreCRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }      
    }
}
