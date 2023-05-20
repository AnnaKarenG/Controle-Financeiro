using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;


namespace WebApp_ControleDeGastos.Repository
{
    public class CardRepository : ICard
    {
        private readonly string _connectionString;

        public CardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public List<Card> GetAllCard()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllCard", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                List<Card> cards = new List<Card>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Card card = new Card();
                        card.CardId = (int)(long)reader["CardId"];
                        card.NumberCard = (int)(long)reader["NumberCard"];
                        //card.type = (Enum.Enums.CardType)reader["Type"];
                        card.Balance = (float)(decimal)reader["Balance"];
                        card.Limite = (float)(decimal)reader["Limite"];
                        card.InvoiceAmount = (float)(decimal)reader["InvoiceAmount"];
                        card.InvoiceDate = (System.DateTime)reader["InvoiceDate"];
                        card.Flag = (string)reader["Flag"];
                        card.Nome = (string)reader["Nome"];

                        cards.Add(card);
                    }
                }

                return cards;
            }
        }

        public Card GetCardById(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetCardById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCardId", id);

                connection.Open();

                Card card = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        card = new Card();
                        card.CardId = (int)(long)reader["CardId"];
                        card.NumberCard = (int)(long)reader["NumberCard"];
                        // card.type = (Enum.Enums.CardType)(long)reader["Type"];
                        card.Balance = (float)(decimal)reader["Balance"];
                        card.Limite = (float)(decimal)reader["Limite"];
                        card.InvoiceAmount = (float)(decimal)reader["InvoiceAmount"];
                        card.InvoiceDate = (System.DateTime)reader["InvoiceDate"];
                        card.Flag = (string)reader["Flag"];
                        card.Nome = (string)reader["Nome"];
                    }
                }

                return card;
            }
        }

        public async Task<Card> AddCard(Card card)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("AddCard", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramNumberCard", card.NumberCard);
                command.Parameters.AddWithValue("@paramtype", card.type);
                command.Parameters.AddWithValue("@paramBalance", card.Balance);
                command.Parameters.AddWithValue("@paramLimite", card.Limite);
                command.Parameters.AddWithValue("@paramInvoiceAmount", card.InvoiceAmount);
                command.Parameters.AddWithValue("@paramInvoiceDate", card.InvoiceDate);
                command.Parameters.AddWithValue("@paramFlag", card.Flag);
                command.Parameters.AddWithValue("@paramNome", card.Nome);

                connection.Open();

                int cardId = (int)(decimal)await command.ExecuteScalarAsync();

                card.CardId = cardId;

                return card;
            }
        }

        public async Task<Card> UpdateCard(Card card)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateCard", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCardId", card.CardId);
                command.Parameters.AddWithValue("@paramNumberCard", card.NumberCard);
                command.Parameters.AddWithValue("@paramtype", card.type);
                command.Parameters.AddWithValue("@paramBalance", card.Balance);
                command.Parameters.AddWithValue("@paramLimite", card.Limite);
                command.Parameters.AddWithValue("@paramInvoiceAmount", card.InvoiceAmount);
                command.Parameters.AddWithValue("@paramInvoiceDate", card.InvoiceDate);
                command.Parameters.AddWithValue("@paramFlag", card.Flag);
                command.Parameters.AddWithValue("@paramNome", card.Nome);

                connection.Open();

                await command.ExecuteNonQueryAsync();

                return card;
            }
        }

        public async Task<bool> DeleteCard(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteCard", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCardId", id);

                connection.Open();

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }
    }
}

/*private readonly SistemaFinanceiroDBContext dbContext;
public CardRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
{

    dbContext = sistemaFinanceiroDBContext;
}

public List<Card> GetAllCard()
{
    return dbContext.Card.ToList();
}

public async Task<Card> GetCardById(long id)
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
        cardId.NumberCard = card.NumberCard;
        cardId.type = card.type;
        cardId.Balance = card.Balance;
        cardId.Limite = card.Limite;
        cardId.InvoiceAmount = card.InvoiceAmount;
        cardId.InvoiceDate = card.InvoiceDate;
        cardId.Flag = card.Flag;
        cardId.UserId = card.UserId;
        dbContext.Card.Update(cardId);
        await dbContext.SaveChangesAsync();

        return cardId;
    }
    else
    {
        throw new Exception($"Cartão não encontrado");
    }
}

public async Task<bool> DeleteCard(long id)
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
*/