using Microsoft.AspNetCore.Mvc;

namespace WebApp_ControleDeGastos.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        public IActionResult UpdateCategory()
        {
            return View();
        }

        public IActionResult DeleteCategory()
        {
            return View();
        }
    }
}
