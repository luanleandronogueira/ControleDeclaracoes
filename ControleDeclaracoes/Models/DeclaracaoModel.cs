using System.ComponentModel.DataAnnotations;

namespace ControleDeclaracoes.Models
{
    public class DeclaracaoModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TituloDeclaracao { get; set; }

        [Required]
        [MaxLength(100)]
        public string EntidadeDeclaracao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }
    }
}
