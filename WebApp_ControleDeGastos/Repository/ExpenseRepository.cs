using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApp_ControleDeGastos.Database;
using WebApp_ControleDeGastos.Models;
using WebApp_ControleDeGastos.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApp_ControleDeGastos.Repository
{
    public class ExpenseRepository : IExpense
    {
        private readonly string _connectionString;

        public ExpenseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public List<Expense> GetAllExpense()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllExpense", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                List<Expense> expenses = new List<Expense>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Expense expense = new Expense();
                        expense.ExpenseId = (int)(long)reader["ExpenseId"];
                        expense.Value = (float)(decimal)reader["Value"];
                        expense.Description = (string)reader["Description"];
                        //expense.type = (Enum.Enums.PaymentType)reader["Type"];
                        expense.NumberInstallments = (int)(long)reader["NumberInstallments"];
                        //expense.status = (Enum.Enums.Status)reader["Type"];
                        expense.NumberCard = (int)(long)reader["NumberCard"];
                        expense.Date = (System.DateTime)reader["Date"];
                        expense.CategoryId = (int)(long)reader["CategoryId"];
                        expense.UserId = (int)(long)reader["UserId"];

                        expenses.Add(expense);
                    }
                }

                return expenses;
            }
        }

        public Expense GetExpenseById(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetExpenseById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramExpenseId", id);

                connection.Open();

                Expense expense = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        expense = new Expense();
                        expense.ExpenseId = (int)(long)reader["ExpenseId"];
                        expense.Value = (float)(decimal)reader["Value"];
                        expense.Description = (string)reader["Description"];
                        //expense.type = (Enum.Enums.PaymentType)reader["Type"];
                        expense.NumberInstallments = (int)(long)reader["NumberInstallments"];
                        //expense.status = (Enum.Enums.Status)reader["Type"];
                        expense.NumberCard = (int)(long)reader["NumberCard"];
                        expense.Date = (System.DateTime)reader["Date"];
                        expense.CategoryId = (int)(long)reader["CategoryId"];
                        expense.UserId = (int)(long)reader["UserId"];
                    }
                }

                return expense;
            }
        }

        public async Task<Expense> AddExpense(Expense expense)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("AddExpense", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@paramValue", expense.Value);
                command.Parameters.AddWithValue("@paramDescription", expense.Description);
                command.Parameters.AddWithValue("@paramtype", expense.type);
                command.Parameters.AddWithValue("@paramNumberInstallments", expense.NumberInstallments);
                command.Parameters.AddWithValue("@paramStatus", expense.Status);
                command.Parameters.AddWithValue("@paramNumberCard", expense.NumberCard);
                command.Parameters.AddWithValue("@paramDate", expense.Date);
                command.Parameters.AddWithValue("@paramCategoryId", expense.CategoryId);
                command.Parameters.AddWithValue("@paramUserId", expense.UserId);

                connection.Open();

                int expenseId = (int)(decimal)await command.ExecuteScalarAsync();

                expense.ExpenseId = expenseId;

                return expense;
            }
        }

        public async Task<Expense> UpdateExpense(Expense expense)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateExpense", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DeleteExpense", expense.ExpenseId);
                command.Parameters.AddWithValue("@paramValue", expense.Value);
                command.Parameters.AddWithValue("@paramDescription", expense.Description);
                command.Parameters.AddWithValue("@paramtype", expense.type);
                command.Parameters.AddWithValue("@paramNumberInstallments", expense.NumberInstallments);
                command.Parameters.AddWithValue("@paramStatus", expense.Status);
                command.Parameters.AddWithValue("@paramNumberCard", expense.NumberCard);
                command.Parameters.AddWithValue("@paramDate", expense.Date);
                command.Parameters.AddWithValue("@paramCategoryId", expense.CategoryId);
                command.Parameters.AddWithValue("@paramUserId", expense.UserId);

                connection.Open();

                await command.ExecuteNonQueryAsync();

                return expense;
            }
        }

        public async Task<bool> DeleteExpense(long id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteExpense", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DeleteExpense", id);

                connection.Open();

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }
    }
}

        /*public ExpenseRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {

            dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<List<Expense>> GetAllExpense()
        {
            return await dbContext.Expense.ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            return await dbContext.Expense.FirstOrDefaultAsync(x => x.ExpenseId == id);
        }

        public async Task<Expense> AddExpense(Expense expense)
        {
            dbContext.Expense.Add(expense);
            await dbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateExpense(Expense expense)
        {
            Expense expenseId = await dbContext.Expense.FirstOrDefaultAsync(x => x.ExpenseId == expense.ExpenseId);

            if (expenseId != null)
            {
                expenseId.Value = expense.Value;
                expenseId.Description = expense.Description;
                expenseId.type = expense.type;
                expenseId.NumberInstallments = expense.NumberInstallments;
                expenseId.Status = expense.Status;
                expenseId.NumberCard = expense.NumberCard;
                expenseId.Date = expense.Date;
                expenseId.CategoryName = expense.CategoryName;
                expenseId.UserId = expense.UserId;
                dbContext.Expense.Update(expenseId);
                await dbContext.SaveChangesAsync();

                return expenseId;
            }
            else
            {
                throw new Exception($"Despesa não encontra");

            }
        }
        public async Task<bool> DeleteExpense(int id)
        {
            Expense expenseid = await GetExpenseById(id);

            if (expenseid == null)
            {
                throw new Exception($"Despesa não encontrado");
            }
            else
            {
                dbContext.Expense.Remove(expenseid);
                await dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}*/