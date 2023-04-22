using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using Microsoft.EntityFrameworkCore;
using WebApp_ControleDeGastos.Repository.Interface;
using System.Linq;
using System.Xml.Linq;

namespace WebApp_ControleDeGastos.Repository
{
    public class CardRepository : ICard
    {
        private readonly SistemaFinanceiroDBContext dbContext;
        public CardRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<Card>> GetAllCard()
        {
            return await dbContext.Card.ToListAsync();
        }

        public async Task<Card> GetCardById(int id)
        {
            return await dbContext.Card.FirstOrDefaultAsync(x => x.CardId == id);
        }

        public async Task<Card> AddCard(Card card)
        {
            dbContext.Card.Add(card);
            await dbContext.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateCard(Card card)
        {
            Card cardId = await dbContext.Card.FirstOrDefaultAsync(x => x.CardId == card.CardId);

            if (cardId != null)
            {     
                card.CardId = cardId.CardId;
                dbContext.Card.Update(cardId);
                await dbContext.SaveChangesAsync();

                return cardId;
            }
            else
            {
                throw new Exception($"Cartão não encontrado");
            }
        }

        public async Task<bool> DeleteCard(int id)
        {
            Card cardId = await GetCardById(id);

            if (cardId == null)
            {
                throw new Exception($"Cartão não encontrado");
            }
            else
            {
                dbContext.Card.Remove(cardId);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
