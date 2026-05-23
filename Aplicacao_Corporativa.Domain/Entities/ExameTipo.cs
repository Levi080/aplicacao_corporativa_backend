using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("exametipo")]
    public class ExameTipo
    {
        public int ExameTipoId { get; set; }

        public string Nome { get; set; } = null!;
    }
}
