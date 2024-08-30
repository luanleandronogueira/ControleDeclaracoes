using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ControleDeclaracoes.Models
{
    public class DeclaracaoViewModel
    {
        public string ?Id { get; set; } // ID da Declaração (caso seja necessário)

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        public string TituloDeclaracao { get; set; }

        [Required(ErrorMessage = "Por favor, selecione uma Entidade.")]
        public string EntidadeDeclaracao { get; set; } // Para capturar o Id da entidade selecionada

        [BindNever]
        public List<SelectListItem>? Entidades { get; set; } // Lista para popular o dropdown

        [Required(ErrorMessage = "O campo Data de Vencimento é obrigatório.")]
        public DateTime DataVencimento { get; set; }
    }
}

