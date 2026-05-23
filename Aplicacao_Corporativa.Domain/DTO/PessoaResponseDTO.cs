using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Corporativa.Domain.DTO
{
    public class PessoaResponseDTO
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public DateTime Nascimento { get; set; }
        public string? Telefone { get; set; }
        public int PessoaTipoId { get; set; }
        public string DescricaoTipoPessoa { get; set; } = null!; // Ex: "Paciente" ou "Técnico"
        public int? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
