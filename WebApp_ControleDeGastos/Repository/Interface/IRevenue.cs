using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IRevenue
    {
        Task<List<Revenue>> Search();
        Task<Revenue> SearchId(int id);
        Task<Revenue> Add(Revenue revenue);
        Task<Revenue> Update(Revenue revenue, int id);
        Task<bool> Delete(int id);
    }
}