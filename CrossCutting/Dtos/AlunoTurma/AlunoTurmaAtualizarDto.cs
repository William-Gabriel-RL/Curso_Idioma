using CrossCutting.Dtos.Base;
using static CrossCutting.Enums.StatusAluno;
using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.AlunoTurma
{
    public class AlunoTurmaAtualizarDto : BaseAtualizarDto
    {
        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int TurmaId { get; set; }

        public DateTime DataInscricao { get; set; }

        public DateTime DataEncerramento { get; set; }

        public StatusDoAluno Status { get; set; }

        public bool Ativo { get; set; }
    }
}
