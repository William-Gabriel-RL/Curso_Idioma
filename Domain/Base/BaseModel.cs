using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
