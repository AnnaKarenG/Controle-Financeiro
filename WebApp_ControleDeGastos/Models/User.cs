using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_ControleDeGastos.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required]
        public string Avatar { get; set; }
    }
}
