using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_ControleDeGastos.Autentication;

namespace WebApp_ControleDeGastos.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }

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

        public void SetPasswordHash()
        {
            Password = Password.GerarHash();
        }
    }
}
