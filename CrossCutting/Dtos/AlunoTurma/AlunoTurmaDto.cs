using static CrossCutting.Enums.StatusAluno;

namespace CrossCutting.Dtos.AlunoTurma
{
    public class AlunoTurmaDto
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }

        public int TurmaId { get; set; }

        public DateTime DataInscricao { get; set; }

        public DateTime DataEncerramento { get; set; }

        public StatusDoAluno Status { get; set; }
    }
}
