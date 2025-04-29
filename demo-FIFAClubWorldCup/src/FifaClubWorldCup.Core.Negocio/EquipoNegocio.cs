using FifaClubWorldCup.Core.Datos;
using FifaClubWorldCup.Core.Entidades;

namespace FifaClubWorldCup.Core.Negocio
{
    public class EquipoNegocio
    {
        
        //public EquipoNegocios(FifaClubWorldCupDbContext context)
        //{
        //    _context = context;
        //}
     
        public List<Equipo> Listado()
        {
            var equipoRepository = new EquipoRepository();

            return equipoRepository.Listado();
        }
    }
    
}
