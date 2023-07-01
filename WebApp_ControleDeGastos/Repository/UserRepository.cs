using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos.Repository
{
    public class UserRepository : IUser
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public List<User> GetAllUser()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                List<User> usuarios = new List<User>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserId = (int)(long)reader["UserId"];
                        user.Name = (string)reader["Name"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                        user.Avatar = (string)reader["Avatar"];

                        usuarios.Add(user);
                    }
                }

                return usuarios;
            }
        }

        public User GetUserById(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetUserById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramUserId", id);

                connection.Open();

                User user = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User();
                        user.UserId = (int)(long)reader["UserId"];
                        user.Name = (string)reader["Name"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                        user.Avatar = (string)reader["Avatar"];
                    }
                }

                return user;
            }
        }

        public async Task<User> AddUser(User user, IFormFile avatar)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("AddUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramName", user.Name);
                command.Parameters.AddWithValue("@paramEmail", user.Email);
                command.Parameters.AddWithValue("@paramPassword", user.Password);

                //Verificando se foi fornecido um avatar
                if (avatar != null && avatar.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await avatar.CopyToAsync(memoryStream);
                        user.Avatar = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }

                command.Parameters.AddWithValue("@paramAvatar", user.Avatar);

                connection.Open();

                int userId = (int)(decimal)await command.ExecuteScalarAsync();

                user.UserId = userId;

                return user;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCardId", user.UserId);
                command.Parameters.AddWithValue("@paramName", user.Name);
                command.Parameters.AddWithValue("@paramEmail", user.Email);
                command.Parameters.AddWithValue("@paramPassword", user.Password);
                command.Parameters.AddWithValue("@paramAvatar", user.Avatar);

                connection.Open();

                await command.ExecuteNonQueryAsync();

                return user;
            }
        }

        public async Task<bool> DeleteUser(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramUserId", id);

                connection.Open();

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }
    }
}
//{
//    private readonly SistemaFinanceiroDBContext dbContext;
//    public UserRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
//    {

//        dbContext = sistemaFinanceiroDBContext;
//    }

//    public async Task<List<User>> GetAllUser()
//    {
//        return await dbContext.User.ToListAsync();
//    }

//    public async Task<User> GetUserById(long id)
//    {
//        return await dbContext.User.FirstOrDefaultAsync(x => x.UserId == id);
//    }

//    public async Task<User> AddUser(User user)
//    {
//        dbContext.User.Add(user);
//        await dbContext.SaveChangesAsync();
//        return user;
//    }

//    public async Task<User> UpdateUser(User user)
//    {
//        User userId = await dbContext.User.FirstOrDefaultAsync(x => x.UserId == user.UserId);

//        if (userId != null)
//        {
//            user.UserId = userId.UserId;
//            dbContext.User.Update(userId);
//            await dbContext.SaveChangesAsync();
//            return userId;
//        }
//        else
//        {
//            throw new Exception($"Usuário não encontrado");
//        }
//    }

//    public async Task<bool> DeleteUser(long id)
//    {
//        User userid = await GetUserById(id);

//        if (userid == null)
//        {
//            throw new Exception($"Usuário não encontrado");
//        }

//        dbContext.User.Remove(userid);
//        await dbContext.SaveChangesAsync();
//        return true;
//    }
//}