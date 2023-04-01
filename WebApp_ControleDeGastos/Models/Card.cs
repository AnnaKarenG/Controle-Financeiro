using System;
using static WebApp_ControleDeGastos.Enum.Enums;

namespace WebApp_ControleDeGastos.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int NumberCard { get; set; }
        public CardType type { get; set; }
        public float Balance { get; set; }
        public float Limite { get; set; }
        public float InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Flag { get; set;}
        public string UserId { get; set;}
    }
}
