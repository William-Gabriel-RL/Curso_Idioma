using Data.Context;
using Data.Interfaces;
using Data.Repositorys.Base;
using Domain;

namespace Data.Repositorys
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        private readonly CadastroTurmaDbContext _context;
        public TurmaRepository(CadastroTurmaDbContext context) : base(context)
        {
            _context = context;
        }

        public new void Remover(int id)
        {
            var obj = _context.Turmas.FirstOrDefault(o => o.Id == id);

            if (obj == null || obj.Ativo == false)
            {
                throw new ArgumentException($"Id {id} não existe");
            }

            if (_context.AlunosTurmas.Where(x => x.TurmaId == obj.Id).Where(x => x.Ativo == true).Any())
            {
                throw new Exception("Turma não pode ser apagada, pois existem alunos inscritos");
            }

            obj.Ativo = false;
            _context.SaveChanges();
        }
    }
}