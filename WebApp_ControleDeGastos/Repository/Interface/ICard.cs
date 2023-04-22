using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface ICard
    {
        Task<List<Card>> GetAllCard();
        Task<Card> GetCardById(int id);
        Task<Card> AddCard(Card card);
        Task<Card> UpdateCard(Card card);
        Task<bool> DeleteCard(int id);
    }
}