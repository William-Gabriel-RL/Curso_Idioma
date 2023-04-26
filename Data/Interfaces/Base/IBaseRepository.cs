namespace Data.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        int Criar(T dto);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarTodos();
        T Atualizar(int id, T dto);
        void Remover(int id);
    }
}
