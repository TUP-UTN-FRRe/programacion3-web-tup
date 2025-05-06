using FifaClubWorldCup.Core.Datos;
using FifaClubWorldCup.Core.Entidades;

namespace FifaClubWorldCup.Core.Negocio
{
    public class EquipoNegocio
    {

        private readonly EquipoRepository _equipoRepository;

        public EquipoNegocio(EquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public List<Equipo> Listado()
        {
            //var equipoRepository = new EquipoRepository();

            return _equipoRepository.Listado();
        }
    }
    
}
