using System.ComponentModel.DataAnnotations;

namespace ControleDeclaracoes.Models
{
    public class EntidadeModel
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Detalhes { get; set; }
    }
}
