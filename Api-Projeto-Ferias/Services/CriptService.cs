using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Api_Projeto_Ferias.Services
{
    public class CriptService
    {
        private static FeriasContext contexto;

        public CriptService(FeriasContext contexto)
        {
            CriptService.contexto = contexto;
        }

        //public static string GeraSenhaCriptografada(Usuario usuario, string senha)
        //{
        //    var saltBytes = new byte[64];
        //    var provider = new RNGCryptoServiceProvider();
        //    provider.GetNonZeroBytes(saltBytes);
        //    var salt = Convert.ToBase64String(saltBytes);

        //    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(senha, saltBytes, 10000);
        //    var senhaHashed = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));


        //    IncluirHashESalt(usuario, senhaHashed, salt);
        //    return senhaHashed;
        //}

        //private static void IncluirHashESalt(Usuario usuario, string hash, string salt)
        //{
        //    usuario.Hash = hash;
        //    usuario.Salt = salt;
        //}

        public static bool ComparaSenhas(string senhaEntrada, string hashDb, string saltDb)
        {
            var saltBytes = Convert.FromBase64String(saltDb);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(senhaEntrada, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == hashDb;
        }

    }
}
