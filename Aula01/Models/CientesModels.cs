using System.ComponentModel.DataAnnotations;

namespace Aula01.Models
{
    public class CientesModels
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Cep { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(20)]
        public string Numero { get; set; }

        [Required]
        [StringLength(20)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
