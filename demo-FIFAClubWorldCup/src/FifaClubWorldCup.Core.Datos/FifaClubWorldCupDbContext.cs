using FifaClubWorldCup.Core.Config;
using FifaClubWorldCup.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaClubWorldCup.Core.Datos
{
    public class FifaClubWorldCupDbContext : DbContext
    {
        private readonly ConfiguracionActual _configuracionActual;

        public FifaClubWorldCupDbContext(ConfiguracionActual configuracionActual)
        {
            _configuracionActual = configuracionActual;
        }

        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuracionActual.FifaClubWorldCupConnectionString);
        }
    }
}
