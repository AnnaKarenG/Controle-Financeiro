using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_ControleDeGastos.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        public string Password { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Avatar { get; set; }
    }
}
