using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("pessoa")]
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public DateTime Nascimento { get; set; }
        public string? Telefone { get; set; }
        public int PessoaTipoId { get; set; }
        public int? AtualizadoPor { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public PessoaTipo Tipo { get; set; } = null!;
    }
}
