using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using Microsoft.EntityFrameworkCore;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos.Repository
{
    public class CardRepository : ICard
    {
        private readonly SistemaFinanceiroDBContext dbContext;
        public CardRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<Card>> Search()
        {
            return await dbContext.Card.ToListAsync();
        }

        public async Task<Card> SearchId(int id)
        {
            return await dbContext.Card.FirstOrDefaultAsync(x => x.CardId == id);
        }

        public async Task<Card> Add(Card card)
        {
            dbContext.Card.Add(card);
            dbContext.SaveChangesAsync();
            return card;
        }

        public async Task<Card> Update(Card card, int id)
        {
            Card cardid = await SearchId(id);

            if (cardid == null)
            {
                throw new Exception($"Cartão não encontrado");
            }
            cardid.NumberCard = card.NumberCard;
            cardid.type = card.type;
            cardid.Balance = card.Balance;
            cardid.Limite = card.Limite;
            cardid.InvoiceAmount = card.InvoiceAmount;
            cardid.InvoiceDate = card.InvoiceDate;
            cardid.Flag = card.Flag;
            cardid.UserId = card.UserId;

            dbContext.Card.Update(cardid);
            await dbContext.SaveChangesAsync();

            return cardid;
        }
        public async Task<bool> Delete(int id)
        {
            Card cardid = await SearchId(id);

            if (cardid == null)
            {
                throw new Exception($"Cartão não encontrado");
            }

            dbContext.Card.Remove(cardid);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
