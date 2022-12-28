using Microsoft.EntityFrameworkCore;
using Projeto_final_AVMB.DataModels;
using Projeto_Final_AVMB.DataModels;
using System.Configuration;

namespace Projeto_Final_AVMB
{
    public class Contexto : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Uniforme> Uniformes { get; set; }
        public DbSet<AlunoUniforme> AlunoUniformes { get; set; }


        public Contexto()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionStringSettings settings = System.Configuration.ConfigurationManager.ConnectionStrings["EntityPostgresql"];
            string retorno = "";

            if (settings != null)
                retorno = settings.ConnectionString;

            optionsBuilder.UseNpgsql(retorno);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoUniforme>()
                .HasKey(x => new {x.alunoId, x.uniformeId});

            modelBuilder.Entity<AlunoUniforme>()
                .HasOne(a => a.aluno)
                .WithMany(u => u.AlunoUniformes)
                .HasForeignKey(a => a.alunoId);

            modelBuilder.Entity<AlunoUniforme>()
                .HasOne(a => a.uniforme)
                .WithMany(u => u.AlunoUniformes)
                .HasForeignKey(a => a.uniformeId);
        }
    }
}
