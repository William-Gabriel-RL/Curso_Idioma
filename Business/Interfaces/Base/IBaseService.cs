namespace Business.Interfaces.Base
{
    public interface IBaseService<T> where T : class
    {
        int Criar(T dto);
        T Atualizar(int id, T dto);
        void Remover(int id);
        T BuscarPorId(int id);
        IEnumerable<T> BuscarPorTodos();
    }
}
