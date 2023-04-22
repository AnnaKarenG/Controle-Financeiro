using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApp_ControleDeGastos.Enum.Enums;

namespace WebApp_ControleDeGastos.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [Column(TypeName = "INT")]
        [Required]
        public int NumberCard { get; set; }

        [Column(TypeName = "TINYINT")]
        [Required]
        public CardType type { get; set; }

        [Column(TypeName = "DECIMAL(15,2)")]
        [Required]
        public float Balance { get; set; }

        [Column(TypeName = "DECIMAL(15,2)")]
        [Required]
        public float Limite { get; set; }

        [Column(TypeName = "DECIMAL(15,2)")]
        public float InvoiceAmount { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? InvoiceDate { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required]
        public string Flag { get; set;}

        [Column(TypeName = "BIGINT")]
        [Required]
        public int UserId { get; set;}
    }
}
