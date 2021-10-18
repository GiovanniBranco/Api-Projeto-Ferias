using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Api_Projeto_Ferias.Services
{
    public class TokenService
    {
        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration Configuration { get; set; }

        public static async Task<string> GeradorToken(Usuario usuario, UserManager<Usuario> userManager)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes("minha-senha-super-forte");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.UserName),
            };

            var roles = await userManager.GetRolesAsync(usuario);
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }


            var descriptador = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateJwtSecurityToken(descriptador);
            return tokenHandler.WriteToken(token);
        }
    }
}
