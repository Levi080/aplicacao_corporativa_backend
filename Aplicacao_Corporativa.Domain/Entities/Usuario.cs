using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Corporativa.Domain.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Column("senha_hash")]
        public byte[] Senha_Hash { get; set; } = null!;
        
        [Column("senha_salt")]
        public byte[] Senha_Salt { get; set; } = null!;

        public bool Ativo { get; set; }
        
        public DateTime DataCriacao { get; set; }
    }
}
