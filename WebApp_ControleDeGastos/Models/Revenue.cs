using System;

namespace WebApp_ControleDeGastos.Models
{
    public class Revenue
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public int UserId { get; set; }
    }
}
