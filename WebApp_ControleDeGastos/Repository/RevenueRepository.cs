using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebApp_ControleDeGastos.Repository
{
    public class RevenueRepository : IRevenue
    {

        private readonly SistemaFinanceiroDBContext dbContext;
        public RevenueRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<Revenue>> GetAllRevenue()
        {
            return await dbContext.Revenue.ToListAsync();
        }

        public async Task<Revenue> GetRevenueById(int id)
        {
            return await dbContext.Revenue.FirstOrDefaultAsync(x => x.RevenueId == id);
        }

        public async Task<Revenue> AddRevenue(Revenue revenue)
        {
            dbContext.Revenue.Add(revenue);
            await dbContext.SaveChangesAsync();
            return revenue;
        }

        public async Task<Revenue> UpdateRevenue(Revenue revenue)
        {
            Revenue revenueId = await dbContext.Revenue.FirstOrDefaultAsync(x => x.RevenueId == revenue.RevenueId);

            if (revenueId != null)
            {
                revenueId.Value = revenue.Value;
                revenueId.UserId = revenue.UserId;
                revenueId.Date = revenue.Date;
                dbContext.Revenue.Update(revenueId);
                await dbContext.SaveChangesAsync();

                return revenueId;
            }
            else
            {
                throw new Exception($"Receita não encontra");
            }
        }
        public async Task<bool> DeleteRevenue(int id)
        {
            Revenue revenueid = await GetRevenueById(id);

            if (revenueid == null)
            {
                throw new Exception($"Receita não encontrado");
            }
            else
            {
                dbContext.Revenue.Remove(revenueid);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
