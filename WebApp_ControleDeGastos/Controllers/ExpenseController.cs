using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace WebApp_ControleDeGastos.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpense _expense;
        private readonly ICard _card;
        private readonly IRevenue _revenue;

        public ExpenseController(IExpense expense, ICard card, IRevenue revenue)
        {
            _card = card;
            _expense = expense;
            _revenue = revenue;
        }

        public async Task <IActionResult> Index()
        {
            List<Expense> expense = _expense.GetAllExpense();
            return View(expense);
        }


        public async Task <IActionResult> UpdateExpense(long id)
        {
            Expense expense =  _expense.GetExpenseById(id);
            return View(expense);
        }

        public async Task <IActionResult> DeleteExpense(long id)
        {
            Expense expense = _expense.GetExpenseById(id);
            return View(expense);
        }

        public async Task <IActionResult> DeleteRecordExpense(long id)
        {
            await _expense.DeleteExpense(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task <IActionResult> ToAddExpense(Expense expense)
        {
            await _expense.AddExpense(expense);
            subLimite(expense);

            return RedirectToAction("Index");
             
        }

        private async void subLimite(Expense expense)
        {
            Card card = _card.GetCardByNumber(expense.NumberCard);
            Revenue revenue = _revenue.GetAllRevenue().Where(x => x.UserId == expense.UserId).First();

            if (revenue != null)
            {
                revenue.Value = revenue.Value - expense.Value;

                await _revenue.UpdateRevenue(revenue);
            }

            if (card != null)
            {
                if (expense.type > Enum.Enums.PaymentType.Credit && expense.Value <= card.Limite)
                    card.Limite = card.Limite - expense.Value;
                else if (expense.type > Enum.Enums.PaymentType.Debit && expense.Value <= card.Balance)
                    card.Balance = card.Balance - expense.Value;
            }

            await _card.UpdateCard(card);
        }

        public async Task<IActionResult> AddExpense(Expense expense)
        {
            return View(); 
        }


        [HttpPost]
        public async Task <IActionResult> ChangeExpense(Expense expense)
        {

           await _expense.UpdateExpense(expense);
            return RedirectToAction("Index");
        }
    }
}