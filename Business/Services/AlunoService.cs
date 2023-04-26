using Business.Interfaces;
using Business.Services.Base;
using CrossCutting.Dtos.Aluno;
using Data.Interfaces;
using Domain;

namespace Business.Services
{
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlunoService(IAlunoRepository repository, IUnitOfWork unitOfWork) : base(repository)
        {
            _unitOfWork = unitOfWork;
        }

        public int CriarAluno(AlunoCriarDto alunoDto)
        {
            if (!ValidaCPF(alunoDto.CPF))
            {
                throw new ArgumentException("cpf do aluno é inválido");
            }

            var aluno = new Aluno
            {
                CPF = alunoDto.CPF,
                Email = alunoDto.Email,
                DataNascimento = alunoDto.DataNascimento,
            };

            var id = _unitOfWork.Aluno.Criar(aluno);

            var inscricaoAlunoTurma = new AlunoTurma()
            {
                AlunoId = id,
                TurmaId = alunoDto.TurmaInicial,
            };

            _unitOfWork.AlunoTurma.Criar(inscricaoAlunoTurma);
            return id;
        }

        public new void Remover(int id)
        {
            _unitOfWork.Aluno.Remover(id);
        }

        public bool ValidaCPF(string cpf)
        {
            if (cpf.Length != 11 || long.TryParse(cpf, out _) == false || cpf == "00000000000")
            {
                return false;
            }

            List<int> multiplicadores = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var numeros = cpf.Select(x => int.Parse(x.ToString())).ToList();

            var penultimoDigito = 0;
            var ultimoDigito = 0;

            for (int i = 0; i < 9; i++)
                penultimoDigito += numeros[i] * multiplicadores[i + 1];

            int restoPenultimo = penultimoDigito % 11;

            if (restoPenultimo == 10)
            {
                restoPenultimo = 0;
            }

            if (restoPenultimo != numeros[9])
            {
                return false;
            }

            for (int i = 0; i < 10; i++)
                ultimoDigito += numeros[i] * multiplicadores[i];


            int restoUltimo = ultimoDigito % 11;

            if (restoUltimo == 10)
            {
                restoUltimo = 0;
            }

            if (restoUltimo != numeros[10])
            {
                return false;
            }

            return true;
        }
    }
}
