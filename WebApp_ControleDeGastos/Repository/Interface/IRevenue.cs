using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IRevenue
    {
        List<Revenue> GetAllRevenue();
        Revenue GetRevenueById(long id);
        Task<Revenue> AddRevenue(Revenue revenue);
        Task<Revenue> UpdateRevenue(Revenue revenue);
        Task<bool> DeleteRevenue(long id);
    }
}