using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IExpense
    {
        Task<List<Expense>> GetAllExpense();
        Task<Expense> GetExpenseById(int id);
        Task<Expense> AddExpense(Expense expense);
        Task<Expense> UpdateExpense(Expense expense);
        Task<bool> DeleteExpense(int id);
    }
}
