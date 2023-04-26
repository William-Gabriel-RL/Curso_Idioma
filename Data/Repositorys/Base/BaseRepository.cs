using Data.Context;
using Data.Interfaces.Base;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorys.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly CadastroTurmaDbContext _context;

        public BaseRepository(CadastroTurmaDbContext context)
        {
            _context = context;
        }

        public virtual int Criar(T dto)
        {
            _context.Set<T>().Add(dto);
            _context.SaveChanges();
            return dto.Id;
        }

        public virtual T BuscarPorId(int id)
        {
            var obj = _context.Set<T>().Where(o => o.Ativo == true).FirstOrDefault(o => o.Id == id);

            if (obj == null)
            {
                throw new ArgumentNullException($"Id {id} não existe");
            }

            return obj;
        }

        public virtual IEnumerable<T> BuscarTodos()
        {
            return _context.Set<T>().Where(o => o.Ativo == true).ToList();
        }

        public virtual T Atualizar(int id, T dto)
        {
            var obj = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                throw new ArgumentNullException($"Id {id} não existe");
            }

            dto.Id = id;
            _context.Entry(obj).State = EntityState.Detached;
            _context.Entry(dto).State = EntityState.Modified;
            _context.SaveChanges();

            return dto;
        }

        public virtual void Remover(int id)
        {
            var obj = _context.Set<T>().FirstOrDefault(o => o.Id == id);

            if (obj == null || obj.Ativo == false)
            {
                throw new ArgumentException($"Id {id} não existe");
            }

            obj.Ativo = false;
            _context.SaveChanges();
        }
    }
}
