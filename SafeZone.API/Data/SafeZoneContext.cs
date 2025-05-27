using Microsoft.EntityFrameworkCore;
using SafeZoneApi.Models;

namespace SafeZoneApi.Data
{
    public class SafeZoneContext : DbContext
    {
        public SafeZoneContext(DbContextOptions<SafeZoneContext> options)
            : base(options)
        {
        }

        public DbSet<Regiao> Regioes { get; set; } = null!;
        public DbSet<Sensor> Sensores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de Regiao (confirme se precisa ajustar aqui depois)
            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.HasKey(r => r.Id);

                // Se não existir campo _id em Regiao, remova essa linha:
                // entity.Property(r => r.Id).HasField("_id").ValueGeneratedOnAdd();

                entity.Property(r => r.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(r => r.Descricao)
                    .HasMaxLength(255);

                entity.HasMany(r => r.Sensores)
                    .WithOne(s => s.Regiao!)
                    .HasForeignKey(s => s.RegiaoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração de Sensor
            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasKey(s => s.Id);

                // Removido .HasField("_id") porque não existe campo _id na classe Sensor
                entity.Property(s => s.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(s => s.UnidadeMedida)
                    .HasMaxLength(20);
            });
        }
    }
}
