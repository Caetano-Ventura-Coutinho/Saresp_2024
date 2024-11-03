using Microsoft.AspNetCore.Mvc;
using Saresp_2024.Models;
using Saresp_2024.Repository.Contract;

namespace Saresp_2024.Controllers
{
    public class AlunoController : Controller
    {
        private IAlunoRepository _AlunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _AlunoRepository = alunoRepository;
        }

        public IActionResult Index()
        {
            return View(_AlunoRepository.ObterTodosAlunos());

        }

        [HttpGet]
        public IActionResult CadastrarAluno()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarAluno(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _AlunoRepository.Cadastrar(aluno);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AtualizarAluno(int Id)
        {
            return View(_AlunoRepository.ObterAluno(Id));
        }
        [HttpPost]
        public IActionResult AtualizarAluno(Aluno aluno)
        {
            _AlunoRepository.Atualizar(aluno);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ExcluirAluno(int id)
        {
            _AlunoRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesAluno(int Id)
        {
            return View(_AlunoRepository.ObterAluno(Id));
        }
        [HttpPost]
        public IActionResult DetalhesAluno(Aluno aluno)
        {
            _AlunoRepository.Atualizar(aluno);

            return RedirectToAction(nameof(Index));
        }
    }
}
