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
        public int ExameId { get; set; }

        public DateTime DataHoraExame { get; set; }

        public int ExameTipoId { get; set; }

        public int PacienteId { get; set; }

        public string? Laudo { get; set; }

        public DateTime AtualizadoEm { get; set; }

        public int? AtualizadoPor { get; set; }

        public virtual ExameTipo Tipo { get; set; } = null!;

        public virtual Pessoa Paciente { get; set; } = null!;

        public int Tecnica { get; set; } = 0!;
    }
}
