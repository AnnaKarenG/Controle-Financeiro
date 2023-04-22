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

        public async Task<List<Revenue>> Search()
        {
            return await dbContext.Revenue.ToListAsync();
        }

        public async Task<Revenue> SearchId(int id)
        {
            return await dbContext.Revenue.FirstOrDefaultAsync(x => x.RevenueId == id);
        }

        public async Task<Revenue> Add(Revenue revenue)
        {
            dbContext.Revenue.Add(revenue);
            dbContext.SaveChangesAsync();
            return revenue;
        }

        public async Task<Revenue> Update(Revenue revenue, int id)
        {
            Revenue revenueid = await SearchId(id);

            if (revenueid == null)
            {
                throw new Exception($"Receita não encontra");
            }
            revenueid.Value = revenue.Value;
            revenueid.UserId = revenue.UserId;
            revenueid.Date = revenue.Date;

            dbContext.Revenue.Update(revenue);
            await dbContext.SaveChangesAsync();

            return revenueid;
        }
        public async Task<bool> Delete(int id)
        {
            Revenue revenueid = await SearchId(id);

            if (revenueid == null)
            {
                throw new Exception($"Receita não encontrado");
            }

            dbContext.Revenue.Remove(revenueid);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
