using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("exame")]
    public class Exame
    {
        [Column("exame_id")]
        public int ExameId { get; set; }

        [Column("datahora_exame")]
        public DateTime DataHoraExame { get; set; }

        [Column("exame_tipo_id")]
        public int ExameTipoId { get; set; }

        [Column("paciente_id")]
        public int PacienteId { get; set; }

        public string? Laudo { get; set; }

        [Column("atualizado_em")]
        public DateTime AtualizadoEm { get; set; }

        [Column("atualizado_por")]
        public int? AtualizadoPor { get; set; }

        public virtual ExameTipo Tipo { get; set; } = null!;

        public virtual Pessoa Paciente { get; set; } = null!;

        public int Tecnica { get; set; } = 0!;
    }
}
