using Data.Context;
using Data.Interfaces;
using Data.Repositorys.Base;
using Domain;

namespace Data.Repositorys
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly CadastroTurmaDbContext _context;
        public AlunoRepository(CadastroTurmaDbContext context) : base(context)
        {
            _context = context;
        }

        public new int Criar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return aluno.Id;
        }

        public new void Remover(int id)
        {
            var obj = _context.Alunos.FirstOrDefault(o => o.Id == id);

            if (obj == null || obj.Ativo == false)
            {
                throw new ArgumentException($"Id {id} não existe");
            }

            if (_context.AlunosTurmas.Where(x => x.AlunoId == obj.Id).Where(x => x.Ativo == true).Any())
            {
                throw new Exception("Aluno não pode ser apagado, pois está matriculado em uma ou mais turmas");
            }

            obj.Ativo = false;
            _context.SaveChanges();
        }
    }
}
