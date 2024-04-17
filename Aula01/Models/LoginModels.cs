using System.ComponentModel.DataAnnotations;

namespace Aula01.Models
{
    public class LoginModels
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
