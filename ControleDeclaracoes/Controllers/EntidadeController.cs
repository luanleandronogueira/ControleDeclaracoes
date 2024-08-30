using ControleDeclaracoes.Models;
using ControleDeclaracoes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeclaracoes.Controllers
{
    public class EntidadeController : Controller
    {
        private readonly IEntidadeRepositorio _entidadeRepositorio;

        public EntidadeController(IEntidadeRepositorio entidadeRepositorio)
        {
            _entidadeRepositorio = entidadeRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult cadastraEntidade(EntidadeModel entidade)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entidade.Detalhes))
                {
                    entidade.Detalhes = "Sem Detalhes";
                }

                _entidadeRepositorio.cadastraEntidade(entidade);
                TempData["MensagemSucesso"] = "Cadastro Feito com Sucesso";

            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Erro ao Cadastrar o contato, erro: {erro.Message}";
            }

            // Redireciona após definir o TempData
            return RedirectToAction("Index");
        }

    }
}
