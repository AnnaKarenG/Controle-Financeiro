using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_ControleDeGastos.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required]
        public string CategoryName { get; set; }
    }
}
