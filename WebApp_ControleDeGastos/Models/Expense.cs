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
        public long ExpenseId { get; set; }

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
        public long NumberInstallments { get; set; }

        [Column(TypeName = "TINYINT")]
        public Status Status { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public long NumberCard { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required]
        public long CategoryId { get; set; }

        [Column(TypeName = "BIGINT")]
        [Required]
        public long UserId { get; set; }

    }
}
