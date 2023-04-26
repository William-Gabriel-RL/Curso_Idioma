using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Aluno : BaseModel
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
    }
}