using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Projeto_Ferias.Data.Configurations
{
    public class FeriasConfiguration : IEntityTypeConfiguration<Ferias>
    {
        public void Configure(EntityTypeBuilder<Ferias> builder)
        {
            builder
                .Property<DateTime>("data_atual")
                .HasDefaultValueSql("getdate()");
        }
    }
}
