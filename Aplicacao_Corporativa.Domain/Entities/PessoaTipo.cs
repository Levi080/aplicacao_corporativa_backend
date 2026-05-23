using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("pessoatipo")]
    public class PessoaTipo
    {
        [Column("pessoa_tipo_id")]
        public int PessoaTipoId { get; set; }

        public string Descricao { get; set; } = null!;
    }
}
