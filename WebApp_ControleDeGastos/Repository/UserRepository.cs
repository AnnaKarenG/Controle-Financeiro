using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos.Repository
{
    public class UserRepository : IUser
    {
        private readonly SistemaFinanceiroDBContext dbContext;
        public UserRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await dbContext.User.ToListAsync();
        }

        public async Task<User> GetUserById(long id)
        {
            return await dbContext.User.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> AddUser(User user)
        {
            dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            User userId = await dbContext.User.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (userId != null)
            {
                user.UserId = userId.UserId;
                dbContext.User.Update(userId);
                await dbContext.SaveChangesAsync();
                return userId;
            }
            else
            {
                throw new Exception($"Usuário não encontrado");
            }
        }

        public async Task<bool> DeleteUser(long id)
        {
            User userid = await GetUserById(id);

            if (userid == null)
            {
                throw new Exception($"Usuário não encontrado");
            }

            dbContext.User.Remove(userid);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
