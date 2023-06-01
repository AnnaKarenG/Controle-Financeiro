using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IExpense
    {
        List<Expense> GetAllExpense();
        Expense GetExpenseById(long id);
        Task<Expense> AddExpense(Expense expense);
        Task<Expense> UpdateExpense(Expense expense);
        Task<bool> DeleteExpense(long id);
    }
}
