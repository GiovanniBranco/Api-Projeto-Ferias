using Api_Projeto_Ferias.Data.Configurations;
using Api_Projeto_Ferias.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Data
{
    public class FeriasContext : IdentityDbContext<Usuario, Role, int,
                                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Ferias> Ferias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public FeriasContext( DbContextOptions options ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FeriasConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
