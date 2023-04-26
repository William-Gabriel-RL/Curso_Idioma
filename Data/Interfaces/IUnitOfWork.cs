namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAlunoRepository Aluno { get; }
        IAlunoTurmaRepository AlunoTurma { get; }
        ITurmaRepository Turma { get; }
        int Commit();
    }
}

