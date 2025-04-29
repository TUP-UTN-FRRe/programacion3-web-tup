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
        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Persist Security Info=True;Initial Catalog=FIFAClubWorldCup;Data Source=.; Integrated Security=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
