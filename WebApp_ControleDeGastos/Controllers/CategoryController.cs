using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp_ControleDeGastos.Controllers
{
    public class CategoryController : Controller
    {
            private readonly ICategory _category;
            public CategoryController(ICategory category) {

                _category = category;
            }

            public IActionResult Index()
            {
                List<Category> category = _category.GetAllCategory();
                return View(category);

            }

 
            public IActionResult UpdateCategory(long id)
            {        //método que chama a tela de edição mostrando os dados

                Category category = _category.GetCategoryById(id);
                return View(category);
            }

            public IActionResult DeleteCategory(long id)
            {    //método que chama a tela de deleção mostrando qual é a categoria

                Category category = _category.GetCategoryById(id);
                return View(category);
            }

            public IActionResult DeleteRecordCategory(long id)
            {
                  _category.DeleteCategory(id);

                    return RedirectToAction("Index");
            }


            public IActionResult AddCategory(Models.Category category)
            {
                 return View();

             }

        public IActionResult ToAddCategory(Models.Category category)
            {
                _category.AddCategory(category);
                return RedirectToAction("Index");

            }


            [HttpPost]
            public IActionResult ChangeCategory(Models.Category category)
            {        //método que chama a tela de edição mostrando os dados

                _category.UpdateCategory(category);
                return RedirectToAction("Index");
            }
             
    }
}
    

