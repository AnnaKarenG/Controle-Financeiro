using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly SistemaFinanceiroDBContext dbContext;
        public CategoryRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<Category> AddCategory(Category category)
        {

            dbContext.Category.Add(category);
            await dbContext.SaveChangesAsync();
            return category;

            //Add verificação posteriormente

            /*string categoryName = category.CategoryName;
            // já existe uma categoria com esse nome
            var foundCategory = await GetCategoryByName(categoryName);

            if (foundCategory != null)
            {
                throw new Exception($"Já existe uma categoria com esse  nome");
            }
            dbContext.Category.Add(category);
            await dbContext.SaveChangesAsync();

            return category;*/
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category categoryId =  GetCategoryById(id);

            if (categoryId == null)
            {
                throw new System.Exception("Categoria não encontrada");
            }

            dbContext.Category.Remove(categoryId);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public List<Category> GetAllCategory()
        {
            return dbContext.Category.ToList();
        }

        public async Task<List<Category>> GetCategoryByName(string name)
        {
            return await dbContext.Set<Category>().Where(c => c.CategoryName.Contains(name)).ToListAsync();
        }

        public Category GetCategoryById(int id)
        {
            return  dbContext.Category.FirstOrDefault(x => x.CategoryId == id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category categoryBD = GetCategoryById(category.CategoryId);

            if (categoryBD != null)
            {
                categoryBD.CategoryName = category.CategoryName;
                dbContext.Category.Update(categoryBD);
                await dbContext.SaveChangesAsync();

            }
            else
            {
                throw new System.Exception("Categoria não encontrada");
            }

            return categoryBD;
        }

  
    }
}
