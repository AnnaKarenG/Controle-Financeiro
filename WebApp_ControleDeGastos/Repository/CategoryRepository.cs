using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;


namespace WebApp_ControleDeGastos.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public List<Category> GetAllCategory()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllCategory", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                List<Category> categories = new List<Category>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.CategoryId = (int)(long)reader["CategoryId"];
                        category.CategoryName = (string)reader["CategoryName"];

                        categories.Add(category);
                    }
                }

                return categories;
            }
        }

        public Category GetCategoryById(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetCategoryById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCategoryId", id);

                connection.Open();

                Category category = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        category = new Category();
                        category.CategoryId = (int)(long)reader["CategoryId"];
                        category.CategoryName = (string)reader["CategoryName"];
                    }
                }

                return category;
            }
        }

        public async Task<Category> AddCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("AddCategory", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCategoryName", category.CategoryName);

                connection.Open();

                int categoryId = (int)(decimal)await command.ExecuteScalarAsync();

                category.CategoryId = categoryId;

                return category;
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateCategory", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCategoryId", category.CategoryId);
                command.Parameters.AddWithValue("@paramCategoryName", category.CategoryName);

                connection.Open();

                await command.ExecuteNonQueryAsync();

                return category;
            }
        }

        public async Task<bool> DeleteCategory(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteCategory", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCategoryId", id);

                connection.Open();

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }

        public async Task<List<Category>> GetCategoryByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetCategoryByName", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCategoryName", name);

                connection.Open();

                List<Category> categories = new List<Category>();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.CategoryName = (string)reader["paramCategoryName"];

                        categories.Add(category);
                    }
                }

                return categories;
            }
        }
    }
}


/*namespace WebApp_ControleDeGastos.Repository
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
*/