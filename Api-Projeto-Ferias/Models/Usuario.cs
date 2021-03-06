using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Api_Projeto_Ferias.Models
{
    [Table("usuario")]
    public class Usuario : IdentityUser<int>
    { 
        public IList<UserRole> UserRoles { get; set; }

        public IList<Ferias> ferias;
    }
}
