using Business.Interfaces.Base;
using CrossCutting.Dtos.Aluno;
using Domain;

namespace Business.Interfaces
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        int CriarAluno(AlunoCriarDto criarAluno);
    }
}
