using Aplicacao_Corporativa.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Aplicacao_Corporativa.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Esse loop resolve o seu problema globalmente para todas as tabelas atuais e futuras!
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // 1. Garante que o EF busque a tabela em minúsculo (ex: "usuario")
                entity.SetTableName(entity.GetTableName().ToLower());

                foreach (var property in entity.GetProperties())
                {
                    // 2. Garante que o EF busque as colunas em minúsculo (ex: "usuarioid", "senha_hash")
                    property.SetColumnName(property.Name.ToLower());
                }
            }

            // Configuração das chaves do Exame (mantenha como estava)
            //modelBuilder.Entity<Exame>(entity =>
            //{
            //    entity.HasOne(e => e.Paciente).WithMany().HasForeignKey(e => e.PacienteId);
            //    entity.HasOne(e => e.Tecnica).WithMany().HasForeignKey(e => e.TecnicaId);
            //});
        }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<PessoaTipo> PessoaTipo { get; set; }

        public DbSet<Exame> Exame { get; set; }

        public DbSet<ExameTipo> ExameTipo { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}


