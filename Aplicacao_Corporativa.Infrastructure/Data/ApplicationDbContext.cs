using Aplicacao_Corporativa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Aplicacao_Corporativa.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // 1. Mantém o nome da tabela em minúsculo
                entity.SetTableName(entity.GetTableName().ToLower());

                foreach (var property in entity.GetProperties())
                {
                    // O PULO DO GATO: Se você já colocou um [Column("nome_com_underscore")] na entidade, 
                    // o EF armazena isso no StoreObjectIdentifier. Nós checamos se ele existe.
                    var storeObject = StoreObjectIdentifier.Table(entity.GetTableName(), entity.GetSchema());
                    var columnNameDefinido = property.GetColumnName(storeObject);

                    // 2. Se a coluna contém um underscore '_', significa que você já mapeou manualmente na classe.
                    // Então nós NÃO tocamos nela, deixamos como está!
                    if (columnNameDefinido != null && columnNameDefinido.Contains("_"))
                    {
                        continue;
                    }

                    // 3. Se não tiver underscore, aí sim aplicamos o ToLower() padrão automaticamente
                    property.SetColumnName(property.Name.ToLower());
                }
            }
        }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<PessoaTipo> PessoaTipo { get; set; }

        public DbSet<Exame> Exame { get; set; }

        public DbSet<ExameTipo> ExameTipo { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}


