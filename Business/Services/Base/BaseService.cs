using Business.Interfaces.Base;
using Data.Interfaces.Base;

namespace Business.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public int Criar(T dto)
        {
            return _repository.Criar(dto);
        }

        public T BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public IEnumerable<T> BuscarPorTodos()
        {
            return _repository.BuscarTodos();
        }

        public T Atualizar(int id, T dto)
        {
            return _repository.Atualizar(id, dto);
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
        }
    }
}
