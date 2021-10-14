using System;
using Api_Projeto_Ferias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Projeto_Ferias.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property<DateTime>("ultima_alteracao")
                .HasDefaultValueSql("getdate()");

            builder
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}
