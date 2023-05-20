using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface ICard
    {
        List<Card> GetAllCard();
        Card GetCardById(long id);
        Task<Card> AddCard(Card card);
        Task<Card> UpdateCard(Card card);
        Task<bool> DeleteCard(long id);
    }
}