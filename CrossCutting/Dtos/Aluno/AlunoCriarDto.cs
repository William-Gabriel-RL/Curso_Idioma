using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.Aluno
{
    public class AlunoCriarDto
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [Required]
        public int TurmaInicial { get; set; }
    }
}
