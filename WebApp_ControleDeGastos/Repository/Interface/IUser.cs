using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IUser
    {
        Task<List<User>> Search();
        Task<User> SearchId(int id);
        Task<User> Add(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
