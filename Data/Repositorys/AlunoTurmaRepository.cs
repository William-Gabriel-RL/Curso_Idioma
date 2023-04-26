using Data.Context;
using Data.Interfaces;
using Data.Repositorys.Base;
using Domain;

namespace Data.Repositorys
{
    public class AlunoTurmaRepository : BaseRepository<AlunoTurma>, IAlunoTurmaRepository
    {
        private readonly CadastroTurmaDbContext _context;
        public AlunoTurmaRepository(CadastroTurmaDbContext context) : base(context)
        {
            _context = context;
        }

        public new int Criar(AlunoTurma alunoTurma)
        {
            if (!_context.Alunos.Where(x => x.Id == alunoTurma.AlunoId).Any())
            {
                throw new Exception("Aluno não existe");
            }

            if (!_context.Turmas.Where(x => x.Id == alunoTurma.TurmaId).Any())
            {
                throw new Exception("Turma não existe");
            }

            if (_context.AlunosTurmas.Where(x => x.AlunoId == alunoTurma.AlunoId).Where(x => x.TurmaId == alunoTurma.TurmaId).Where(x => x.Ativo == true).Any())
            {
                throw new Exception("Aluno já inscrito na turma");
            }

            if (_context.AlunosTurmas.Where(x => x.TurmaId == alunoTurma.TurmaId).Where(x => x.Ativo == true).ToList().Count() > 4)
            {
                throw new Exception("Turma só pode ter 5 alunos inscritos");
            }

            _context.AlunosTurmas.Add(alunoTurma);
            _context.SaveChanges();
            return alunoTurma.Id;
        }
    }
}
