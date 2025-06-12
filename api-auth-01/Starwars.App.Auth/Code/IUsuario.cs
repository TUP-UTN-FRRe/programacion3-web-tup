namespace Starwars.App.Auth.Code
{
    public interface IUsuario
    {
        int UsuarioId { get; }
        string NombreUsuario { get; }
        string Nombre { get; }
        string Apellido { get; }
        //Otros propiedades relevantes para el usuario
    }
}
