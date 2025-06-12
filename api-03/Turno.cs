namespace TurnosApp.Entities;

public class Turno
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public DateTime FechaHora { get; set; }
    public string Servicio { get; set; }
    public string Profesional { get; set; }
    public bool Confirmado { get; set; }

    public Turno()
    {
        
    }
    
    public Turno(string cliente,
                DateTime fechaHora, string servicio, string profesional, bool confirmado)
    {
        Cliente = cliente;
        FechaHora = fechaHora;
        Servicio = servicio;
        Profesional = profesional;
        Confirmado = confirmado;
    }
}