using System.ComponentModel.DataAnnotations.Schema;

namespace FifaClubWorldCup.Core.Entidades
{

    [Table("Equipo")]
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public Pais Pais { get; set; }
        public string ImagenUrl { get; set; }
    }

}
