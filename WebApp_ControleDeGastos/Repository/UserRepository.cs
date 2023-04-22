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

        public async Task<List<User>> Search()
        {
            return await dbContext.User.ToListAsync();
        }

        public async Task<User> SearchId(int id)
        {
            return await dbContext.User.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> Add(User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user, int id)
        {
            User userid =  await SearchId(id);

            if (userid == null)
            {
                throw new Exception($"Usuário não encontrado");
            }
                userid.Name = user.Name;
                userid.Email = user.Email;
                userid.Password = user.Password;
                userid.Avatar = user.Avatar;

            dbContext.User.Update(userid);
            await dbContext.SaveChangesAsync();

            return userid;
        }
        public async Task<bool> Delete(int id)
        {
            User userid = await SearchId(id);

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
