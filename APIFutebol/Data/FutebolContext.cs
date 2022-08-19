using APIFutebol.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFutebol.Data
{
    public class FutebolContext : DbContext
    {

        // Preenchendo o construtuor de DbContext
        public FutebolContext(DbContextOptions<FutebolContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Confronto>()
                .HasOne(confronto => confronto.Resultado)
                .WithOne(resultado => resultado.Confronto)
                .HasForeignKey<Confronto>(confronto => confronto.ResultadoId);

            builder.Entity<Confronto>()
                .HasOne(confronto => confronto.Arbitragem)
                .WithMany(arbitragem => arbitragem.Confrontos)
                .HasForeignKey(confronto => confronto.ArbitragemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Confronto>()
                .HasOne(confronto => confronto.Localizacao)
                .WithMany(localizacao => localizacao.Confrontos)
                .HasForeignKey(confronto => confronto.LocalizacaoId);
        }

        public DbSet<Confronto> Confrontos { get; set; } // Definindo o conjunto que estarei usando para o banco de dados
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }

        public DbSet<Arbitragem> Arbitragens { get; set; }

    }
}
