using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Column("pessoa_id")]
        public int PessoaId { get; set; }

        public string Nome { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public DateTime Nascimento { get; set; }

        public string? Telefone { get; set; }

        [Column("pessoa_tipo_id")]
        public int PessoaTipoId { get; set; }

        [Column("atualizado_por")]
        public int? AtualizadoPor { get; set; }

        [Column("atualizado_em")]
        public DateTime AtualizadoEm { get; set; }

        public PessoaTipo Tipo { get; set; } = null!;
    }
}
