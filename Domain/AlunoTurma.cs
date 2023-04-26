using Domain.Base;
using System.ComponentModel.DataAnnotations;
using static CrossCutting.Enums.StatusAluno;

namespace Domain
{
    public class AlunoTurma : BaseModel
    {
        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int TurmaId { get; set; }

        public DateTime DataInscricao { get; set; } = DateTime.Now;

        public DateTime DataEncerramento { get; set; }

        public StatusDoAluno Status { get; set; } = StatusDoAluno.Cursando;
    }
}