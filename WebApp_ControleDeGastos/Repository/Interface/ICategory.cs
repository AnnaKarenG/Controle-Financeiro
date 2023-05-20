using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface ICategory
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(long id);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(long id);
        Task<List<Category>> GetCategoryByName(string name);
    }
}
