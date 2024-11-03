using Saresp_2024.Models;

namespace Saresp_2024.Repository.Contract
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> ObterTodosAlunos();

        void Cadastrar(Aluno aluno);

        void Atualizar(Aluno aluno);

        Aluno ObterAluno(int Id);

        void Excluir(int Id);
    }
}
