using Business.Interfaces;
using Business.Services.Base;
using Data.Interfaces;
using Domain;

namespace Business.Services
{
    public class AlunoTurmaService : BaseService<AlunoTurma>, IAlunoTurmaService
    {
        public AlunoTurmaService(IAlunoTurmaRepository repository) : base(repository)
        {
        }
    }
}
