using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebApp_ControleDeGastos.Repository
{
    public class ExpenseRepository : IExpense
    {

        private readonly SistemaFinanceiroDBContext dbContext;
        public ExpenseRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<Expense>> Search()
        {
            return await dbContext.Expense.ToListAsync();
        }

        public async Task<Expense> SearchId(int id)
        {
            return await dbContext.Expense.FirstOrDefaultAsync(x => x.ExpenseId == id);
        }

        public async Task<Expense> Add(Expense expense)
        {
            dbContext.Expense.Add(expense);
            dbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> Update(Expense expense, int id)
        {
            Expense expenseid = await SearchId(id);

            if (expenseid == null)
            {
                throw new Exception($"Despesa não encontra");
            }
            expenseid.Value = expense.Value;
            expenseid.Description = expense.Description;
            expenseid.type = expense.type;
            expenseid.NumberInstallments = expense.NumberInstallments;
            expenseid.Status = expense.Status;
            expenseid.NumberCard = expense.NumberCard;
            expenseid.CategoryName = expense.CategoryName;
            expenseid.Date = expense.Date;
            expenseid.UserId = expense.UserId;

            dbContext.Expense.Update(expense);
            await dbContext.SaveChangesAsync();

            return expenseid;
        }
        public async Task<bool> Delete(int id)
        {
            Expense expenseid = await SearchId(id);

            if (expenseid == null)
            {
                throw new Exception($"Despesa não encontrado");
            }

            dbContext.Expense.Remove(expenseid);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}























