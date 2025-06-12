namespace Starwars.App.Auth.Code
{
    public class Usuario: IUsuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Otros propiedades relevantes para el usuario
    }
}
