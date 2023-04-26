using CrossCutting.Dtos.Base;
using static CrossCutting.Enums.NivelTurma;
using static CrossCutting.Enums.StatusTurma;
using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.Turma
{
    public class TurmaAtualizarDto : BaseAtualizarDto
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public int AnoLetivo { get; set; }

        [Required]
        public Nivel Nivel { get; set; }

        [Required]
        public StatusDaTurma Status { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
