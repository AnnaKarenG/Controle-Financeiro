using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface ICard
    {
        Task<List<Card>> Search();
        Task<Card> SearchId(int id);
        Task<Card> Add(Card card);
        Task<Card> Update(Card card, int id);
        Task<bool> Delete(int id);
    }
}