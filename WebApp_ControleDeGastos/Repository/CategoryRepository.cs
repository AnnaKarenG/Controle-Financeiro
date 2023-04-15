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
        private readonly CategoryDBContext dbContext;
        public CategoryRepository(CategoryDBContext categoryDBContext)
        {
            dbContext = categoryDBContext;
        }

        public async Task<Category> AddCategory(Category category)
        {
            string categoryName = category.CategoryName;
            // já existe uma categoria com esse nome
            var foundCategory = await GetCategoryByName(categoryName);

            if (foundCategory != null)
            {
                throw new Exception($"Já existe uma categoria com esse  nome");
            }
            dbContext.Category.Add(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category categoryId = await GetCategoryById(id);

            if (categoryId == null)
            {
                throw new Exception($"Categoria não encontrada");
            }

            dbContext.Category.Remove(categoryId);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await dbContext.Category.ToListAsync();
        }

        public async Task<List<Category>> GetCategoryByName(string name)
        {
            return await dbContext.Set<Category>().Where(c => c.CategoryName.Contains(name)).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category categoryId = await dbContext.Set<Category>().FirstOrDefaultAsync(c => c.Id == category.Id);

            if (categoryId != null)
            {
                category.CategoryName = categoryId.CategoryName;
                dbContext.Category.Update(category);
                await dbContext.SaveChangesAsync();

            }
            else
            {
                throw new Exception($"Categoria não encontrada");
            }

            return categoryId;
        }
    }
}
