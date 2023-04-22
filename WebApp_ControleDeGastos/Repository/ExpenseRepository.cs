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

        public async Task<List<Expense>> GetAllExpense()
        {
            return await dbContext.Expense.ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            return await dbContext.Expense.FirstOrDefaultAsync(x => x.ExpenseId == id);
        }

        public async Task<Expense> AddExpense(Expense expense)
        {
            dbContext.Expense.Add(expense);
            await dbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateExpense(Expense expense)
        {
            Expense expenseId = await dbContext.Expense.FirstOrDefaultAsync(x => x.ExpenseId == expense.ExpenseId);

            if (expenseId != null)
            {
                expense.ExpenseId = expenseId.ExpenseId;
                dbContext.Expense.Update(expense);
                await dbContext.SaveChangesAsync();

                return expenseId;
            }
            else
            {
                throw new Exception($"Despesa não encontra");

            }
        }
        public async Task<bool> DeleteExpense(int id)
        {
            Expense expenseid = await GetExpenseById(id);

            if (expenseid == null)
            {
                throw new Exception($"Despesa não encontrado");
            }
            else
            {
                dbContext.Expense.Remove(expenseid);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}























