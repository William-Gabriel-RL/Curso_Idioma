using Business.Interfaces;
using Business.Services.Base;
using Data.Interfaces;
using Domain;

namespace Business.Services
{
    public class TurmaService : BaseService<Turma>, ITurmaService
    {
        public TurmaService(ITurmaRepository repository) : base(repository)
        {
        }
    }
}