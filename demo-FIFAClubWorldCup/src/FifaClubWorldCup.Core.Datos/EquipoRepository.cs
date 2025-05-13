using FifaClubWorldCup.Core.Config;
using FifaClubWorldCup.Core.Entidades;

namespace FifaClubWorldCup.Core.Datos
{
    public class EquipoRepository
    {
        private ConfiguracionActual _configuracionActual;

        public EquipoRepository(ConfiguracionActual configuracionActual)
        {            
            _configuracionActual = configuracionActual;
        }


        public List<Equipo> Listado()
        {
            using (var dbContext = new FifaClubWorldCupDbContext(_configuracionActual))
            {
                return dbContext.Equipos.ToList();
            }
           
        }
    }
}
