using System.ComponentModel.DataAnnotations;
using static CrossCutting.Enums.NivelTurma;

namespace CrossCutting.Dtos.Turma
{
    public class TurmaCriarDto
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public int AnoLetivo { get; set; }

        [Required]
        public Nivel Nivel { get; set; }
    }
}
