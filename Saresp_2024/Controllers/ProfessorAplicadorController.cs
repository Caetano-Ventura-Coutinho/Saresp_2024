using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Saresp_2024.Models;
using Saresp_2024.Repository.Contract;

namespace Saresp_2024.Controllers
{
    public class ProfessorAplicadorController : Controller
    {
        private IProfessorAplicadorRepository _ProfessorAplicadorRepository;

        public ProfessorAplicadorController(IProfessorAplicadorRepository professorAplicadorRepository)
        {
            _ProfessorAplicadorRepository = professorAplicadorRepository;
        }

        public IActionResult Index()
        {
            return View(_ProfessorAplicadorRepository.ObterTodosProfessoresAplicadores());

        }

        [HttpGet]
        public IActionResult CadastrarProfessorAplicador()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarProfessorAplicador(ProfessorAplicador professorAplicador)
        {
            if (ModelState.IsValid)
            {
                _ProfessorAplicadorRepository.Cadastrar(professorAplicador);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AtualizarProfessorAplicador(int Id)
        {
            return View(_ProfessorAplicadorRepository.ObterProfessorAplicador(Id));
        }
        [HttpPost]
        public IActionResult AtualizarProfessorAplicador(ProfessorAplicador professorAplicador)
        {
            _ProfessorAplicadorRepository.Atualizar(professorAplicador);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ExcluirProfessorAplicador(int id)
        {
            _ProfessorAplicadorRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesProfessorAplicador(int Id)
        {
            return View(_ProfessorAplicadorRepository.ObterProfessorAplicador(Id));
        }
        [HttpPost]
        public IActionResult DetalhesProfessorAplicador(ProfessorAplicador professorAplicador)
        {
            _ProfessorAplicadorRepository.Atualizar(professorAplicador);

            return RedirectToAction(nameof(Index));
        }
    }
}
