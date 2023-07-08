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