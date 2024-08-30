using ControleDeclaracoes.Models;
using ControleDeclaracoes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeclaracoes.Controllers
{
    public class DeclaracaoController : Controller
    {
        private readonly IEntidadeRepositorio _entidadeRepositorio;
        private readonly IDeclaracaoRepositorio _declaracaoRepositorio;

        public DeclaracaoController(IEntidadeRepositorio entidadeRepositorio, IDeclaracaoRepositorio declaracaoRepositorio)
        {
            _entidadeRepositorio = entidadeRepositorio;
            _declaracaoRepositorio = declaracaoRepositorio;
        }

        // Carrega o formulário
        public IActionResult Index()
        {
            var ent = _entidadeRepositorio.chamaEntidades();
            var viewModel = new DeclaracaoViewModel();

            viewModel.Entidades = new List<SelectListItem>();
            foreach (var entidade in ent)
            {
                viewModel.Entidades.Add(new SelectListItem { Text = entidade.Nome, Value = entidade.Nome });
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Declaracao(DeclaracaoViewModel declaracaoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var declaracaoModel = new DeclaracaoModel
                    {
                        TituloDeclaracao = declaracaoViewModel.TituloDeclaracao,
                        EntidadeDeclaracao = declaracaoViewModel.EntidadeDeclaracao,
                        DataVencimento = declaracaoViewModel.DataVencimento,
                    };

                    _declaracaoRepositorio.cadastraDeclaracao(declaracaoModel);
                    TempData["MensagemSucesso"] = "Cadastro Feito com Sucesso";
                }
                catch (System.Exception erro)
                {
                    TempData["MensagemErro"] = $"Erro ao Cadastrar o usuario, erro: {erro.Message}";
                }
            }
            else
            {
                // Captura os erros e mostra na view
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Loga ou exibe os erros
                }
            }

            return RedirectToAction("Index");
        }


        public IActionResult ListaDeclaracao()
        {
            List<EntidadeModel> Entidades = _entidadeRepositorio.chamaEntidades();
            return View(Entidades);
        }

    }
}
