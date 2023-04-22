using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IExpense
    {
        Task<List<Expense>> Search();
        Task<Expense> SearchId(int id);
        Task<Expense> Add(Expense expense);
        Task<Expense> Update(Expense expense, int id);
        Task<bool> Delete(int id);
    }
}
