using Domain.Base;
using System.ComponentModel.DataAnnotations;
using static CrossCutting.Enums.NivelTurma;
using static CrossCutting.Enums.StatusTurma;

namespace Domain
{
    public class Turma : BaseModel
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public int AnoLetivo { get; set; }

        [Required]
        public Nivel Nivel { get; set; }

        public StatusDaTurma Status { get; set; } = StatusDaTurma.Aberta;
    }
}
