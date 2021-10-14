using System;
using System.Collections.Generic;
using System.Linq;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Projeto_Ferias.Services
{
    public class VerificaProximasFeriasService
    {
        private  readonly FeriasContext _context;

        public VerificaProximasFeriasService(FeriasContext context)
        {
            _context = context;
        }

        public  int CalculaDias (Usuario usuario)
        {
            var feriasFuturas = ObtemFeriasFuturas(usuario);
            
            return (int)feriasFuturas.DataInicioFerias.Subtract(DateTime.Today).TotalDays;
        }

        private  Ferias ObtemProximasFerias(IList<Ferias> feriasFuturas)
        {
            Ferias proximasFerias = feriasFuturas.First();

            foreach (var item in feriasFuturas)
            {
                var resultado = item.DataInicioFerias.CompareTo(proximasFerias.DataInicioFerias);

                if (resultado < 0)
                {
                    proximasFerias = item;
                }
            }

            return proximasFerias;
        }

        public  Ferias ObtemFeriasFuturas(Usuario usuario)
        {
            var dataAtual = DateTime.Now;
            var usuarioFerias = ObtemFeriasUsuario(usuario);
            var feriasFuturas = new List<Ferias>();

            if (usuarioFerias.Count == 0)
            {
                return null;
            }

            foreach (var item in usuarioFerias)
            {
                var resultado = item.DataInicioFerias.CompareTo(dataAtual);

                if (resultado > 0)
                {
                    feriasFuturas.Add(item);
                }
            }

            return ObtemProximasFerias(feriasFuturas);
            
        }

        private IList<Ferias> ObtemFeriasUsuario (Usuario usuario)
        {
            var ferias = _context.Ferias
                .Include(u => u.Usuario)
                .ToList();
                

            return ferias;
        }
    }
}
