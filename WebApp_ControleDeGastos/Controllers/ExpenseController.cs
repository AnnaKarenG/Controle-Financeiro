using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp_ControleDeGastos.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpense _expense;
        public ExpenseController(IExpense expense)
        {

            _expense = expense;
        }

        public async Task <IActionResult> Index()
        {
            List<Expense> expense = await _expense.GetAllExpense();
            return View(expense);

        }


        public async Task <IActionResult> UpdateExpense(int id)
        {

            Expense expense = await _expense.GetExpenseById(id);
            return View(expense);
        }

        public async Task <IActionResult> DeleteExpense(int id)
        {

            Expense expense = await _expense.GetExpenseById(id);
            return View(expense);
        }

        public async Task <IActionResult> DeleteRecordExpense(int id)
        {
            await _expense.DeleteExpense(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task <IActionResult> AddExpense(Expense expense)
        {
          await _expense.AddExpense(expense);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task <IActionResult> ChangeExpense(Expense expense)
        {

           await _expense.UpdateExpense(expense);
            return RedirectToAction("Index");
        }

    }
}


