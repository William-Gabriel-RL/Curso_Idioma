using Data.Context;
using Data.Interfaces;

namespace Data.Repositorys
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadastroTurmaDbContext _context;
        public IAlunoRepository Aluno { get; }
        public IAlunoTurmaRepository AlunoTurma { get; }
        public ITurmaRepository Turma { get; }

        public UnitOfWork(CadastroTurmaDbContext context, IAlunoRepository aluno, IAlunoTurmaRepository alunoTurma, ITurmaRepository turma)
        {
            _context = context;
            Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno));
            AlunoTurma = alunoTurma ?? throw new ArgumentNullException(nameof(alunoTurma));
            Turma = turma ?? throw new ArgumentNullException(nameof(turma));
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}