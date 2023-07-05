using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;

namespace WebApp_ControleDeGastos.Repository
{
    public class RevenueRepository : IRevenue
    {
        private readonly string _connectionString;

        public RevenueRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public List<Revenue> GetAllRevenue()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllRevenue", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                List<Revenue> revenues = new List<Revenue>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Revenue revenue = new Revenue();
                        revenue.RevenueId = (int)(long)reader["RevenueId"];
                        revenue.Value = (float)(decimal)reader["Value"];
                        revenue.UserId = (int)(long)reader["UserId"];
                        revenue.Date = (System.DateTime)reader["Date"];

                        revenues.Add(revenue);
                    }
                }

                return revenues;
            }
        }

        public Revenue GetRevenueById( long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllRevenue", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramCardId", id);

                connection.Open();

                Revenue revenue = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        revenue = new Revenue();
                        revenue.RevenueId = (int)(long)reader["RevenueId"];
                        revenue.Value = (float)(decimal)reader["Value"];
                        revenue.UserId = (int)(long)reader["Limite"];
                        revenue.Date = (System.DateTime)reader["Date"];
                    }
                }
                return revenue;
            }
        }

        public async Task<Revenue> AddRevenue( Revenue revenue)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("AddRevenue", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramValue", revenue.Value);
                command.Parameters.AddWithValue("@paramUserId", revenue.UserId);
                command.Parameters.AddWithValue("@paramDate", revenue.Date);

                connection.Open();

                int revenueId = (int)(decimal)await command.ExecuteScalarAsync();
                //int revenueId = Convert.ToInt32(await command.ExecuteScalarAsync());

                revenue.RevenueId = revenueId;

                return revenue;
            }
        }

        public async Task<Revenue> UpdateRevenue(Revenue revenue)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateRevenue", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramRevenueId", revenue.RevenueId);
                command.Parameters.AddWithValue("@paramValue", revenue.Value);
                command.Parameters.AddWithValue("@paramDate", revenue.Date);

                connection.Open();

                await command.ExecuteNonQueryAsync();

                return revenue;
            }
        }

        public async Task<bool> DeleteRevenue(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteCard", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramRevenueId", id);

                connection.Open();

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }
    }
}
  /* public RevenueRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<Revenue>> GetAllRevenue()
        {
            return await dbContext.Revenue.ToListAsync();
        }

        public async Task<Revenue> GetRevenueById(int id)
        {
            return await dbContext.Revenue.FirstOrDefaultAsync(x => x.RevenueId == id);
        }

        public async Task<Revenue> AddRevenue(Revenue revenue)
        {
            dbContext.Revenue.Add(revenue);
            await dbContext.SaveChangesAsync();
            return revenue;
        }

        public async Task<Revenue> UpdateRevenue(Revenue revenue)
        {
            Revenue revenueId = await dbContext.Revenue.FirstOrDefaultAsync(x => x.RevenueId == revenue.RevenueId);

            if (revenueId != null)
            {
                revenueId.Value = revenue.Value;
                revenueId.UserId = revenue.UserId;
                revenueId.Date = revenue.Date;
                dbContext.Revenue.Update(revenueId);
                await dbContext.SaveChangesAsync();

                return revenueId;
            }
            else
            {
                throw new Exception($"Receita não encontra");
            }
        }
        public async Task<bool> DeleteRevenue(int id)
        {
            Revenue revenueid = await GetRevenueById(id);

            if (revenueid == null)
            {
                throw new Exception($"Receita não encontrado");
            }
            else
            {
                dbContext.Revenue.Remove(revenueid);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }*/

