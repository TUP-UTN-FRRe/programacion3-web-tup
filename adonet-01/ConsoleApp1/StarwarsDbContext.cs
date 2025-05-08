using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class StarwarsDbContext: DbContext
    {
        public DbSet<Jedi> Jedis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringStarwars = "Persist Security Info=True;Initial Catalog=Starwars;Data Source=.; Integrated Security=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionStringStarwars);
        }
    }
}
