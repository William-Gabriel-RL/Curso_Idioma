using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.AlunoTurma
{
    public class AlunoTurmaCriarDto
    {
        [Required]
        public int AlunoId { get; set; }

        [Required]
        public int TurmaId { get; set; }
    }
}