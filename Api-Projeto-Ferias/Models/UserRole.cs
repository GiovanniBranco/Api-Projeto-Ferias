using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Api_Projeto_Ferias.Models
{
    [Table("user_role")]
    public class UserRole : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Role Role { get; set; }
    }
}