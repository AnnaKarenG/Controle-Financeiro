using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApp_ControleDeGastos.Enum.Enums;

namespace WebApp_ControleDeGastos.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Column(TypeName = "DECIMAL(15,2)")]
        [Required]
        public float Value { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        public string Description { get; set; }

        [Column(TypeName = "TINYINT")]
        [Required]
        public PaymentType type  { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public int NumberInstallments { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        public Status Status { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public int NumberCard { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required]
        public string CategoryName { get; set; }

        [Column(TypeName = "BIGINT")]
        [Required]
        public int UserId { get; set; }

    }
}
