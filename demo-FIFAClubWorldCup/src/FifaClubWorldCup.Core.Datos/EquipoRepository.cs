using FifaClubWorldCup.Core.Entidades;

namespace FifaClubWorldCup.Core.Datos
{
    public class EquipoRepository
    {
        public List<Equipo> Listado()
        {

            var dbContext = new FifaClubWorldCupDbContext();

            return dbContext.Equipos.ToList();
        }
    }
}
