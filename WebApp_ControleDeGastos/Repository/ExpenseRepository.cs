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
using static WebApp_ControleDeGastos.Enum.Enums;

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
                        byte PaymentTypeByte = (byte)reader["Type"];
                        expense.type = (PaymentType)PaymentTypeByte;
                        expense.NumberInstallments = (int)(long)reader["NumberInstallments"];
                        byte status = (byte)reader["Status"];
                        expense.Status = (Status)status;
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
                        byte PaymentTypeByte = (byte)reader["Type"];
                        expense.type = (PaymentType)PaymentTypeByte;
                        expense.NumberInstallments = (int)(long)reader["NumberInstallments"];
                        byte status = (byte)reader["Status"];
                        expense.Status = (Status)status;
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

                command.Parameters.AddWithValue("@paramExpenseId", expense.ExpenseId);
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

                command.Parameters.AddWithValue("@paramExpenseId", id);

                connection.Open();

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0;
            }
        }
    }
}