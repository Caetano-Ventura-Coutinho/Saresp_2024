using Saresp_2024.Models;
namespace Saresp_2024.Repository.Contract
{
    public interface IProfessorAplicadorRepository
    {
        IEnumerable<ProfessorAplicador> ObterTodosProfessoresAplicadores();

        void Cadastrar(ProfessorAplicador professorAplicador);

        void Atualizar(ProfessorAplicador professorAplicador);

        ProfessorAplicador ObterProfessorAplicador(int Id);

        void Excluir(int Id);
    }
}
