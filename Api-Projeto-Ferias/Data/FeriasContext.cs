using Api_Projeto_Ferias.Data.Configurations;
using Api_Projeto_Ferias.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Data
{
    public class FeriasContext : DbContext
    {
        public DbSet<Ferias> Ferias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public FeriasContext( DbContextOptions options ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FeriasConfiguration());
        }
    }
}
