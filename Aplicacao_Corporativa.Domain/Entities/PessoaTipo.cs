using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("pessoatipo")]
    public class PessoaTipo
    {
        public int PessoaTipoId { get; set; }
        public string Descricao { get; set; } = null!;
    }
}
