using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos.Controllers
{
    public class CardController : Controller
    {
        private readonly ICard _card;
        public CardController(ICard card)
        {

            _card = card;
        }

        public IActionResult Index()
        {
            List<Card> card = _card.GetAllCard();
            return View(card);

        }

        public async Task<IActionResult> UpdateCard(long id)
        {       
            Card card = _card.GetCardById(id);
            return View(card);
        }

        public async Task<IActionResult> DeleteCard(long id)
        {   
            Card card = _card.GetCardById(id);
            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRecordCard(long id)
        {
            await _card.DeleteCard(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ToAddCard(Card card)
        {
             await _card.AddCard(card);
            return RedirectToAction("Index");

        }
       
        public async Task<IActionResult> AddCard(Card card)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangeCard(Card card)
        {
            await _card.UpdateCard(card);
            return RedirectToAction("Index");
        }

    }
}