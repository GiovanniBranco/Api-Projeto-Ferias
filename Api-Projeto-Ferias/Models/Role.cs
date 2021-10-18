using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Api_Projeto_Ferias.Models
{
    [Table("role")]
    public class Role : IdentityRole<int>
    {
        public IList<UserRole> UserRoles { get; set; }
    }
}