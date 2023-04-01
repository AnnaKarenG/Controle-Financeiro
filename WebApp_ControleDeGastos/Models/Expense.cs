using System;

namespace WebApp_ControleDeGastos.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string PaymentForm { get; set; }
        public int NumberInstallments { get; set; }
        public string Status { get;}
        public int NumberCard { get; set; }
        public int CategoryName { get; set; }
        public int UserId { get; set; }

    }
}
