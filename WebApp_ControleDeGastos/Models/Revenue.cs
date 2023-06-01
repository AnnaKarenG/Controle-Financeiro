using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_ControleDeGastos.Models
{
    public class Revenue
    {
        [Key]
        public long RevenueId { get; set; }

        [Column(TypeName = "DECIMAL(15,2)")]
        [Required]
        public float Value { get; set; }

        [Column(TypeName = "BIGINT")]
        [Required]
        public long UserId { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required]
        public DateTime Date { get; set; }
    }
}
