using static CrossCutting.Enums.NivelTurma;
using static CrossCutting.Enums.StatusTurma;

namespace CrossCutting.Dtos.Turma
{
    public class TurmaDto
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public int AnoLetivo { get; set; }

        public Nivel Nivel { get; set; }

        public StatusDaTurma Status { get; set; }
    }
}
