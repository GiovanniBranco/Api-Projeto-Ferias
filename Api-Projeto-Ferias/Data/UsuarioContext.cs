using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Data
{
    public class UsuarioContext : DbContext
    {
        //public DbSet<Ferias> DbSetFerias { get; set; }
        public DbSet<Usuario> DbSetUsuario { get; set; }

        public UsuarioContext( DbContextOptions options ) : base(options)
        {
        }
    }
}
