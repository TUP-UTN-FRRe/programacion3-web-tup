using System;
using System.Collections.Generic;
using TurnosApp.Entities;

namespace TurnosApp.Business;
public class TurnoBusiness
{
    private static readonly string[] NombresPacientes =
        { "Juan Perez", "Ana Gomez", "Luis Martinez", "Maria Lopez", "Carlos Diaz" };
    private static readonly string[] Especialidades =
        { "Cardiología", "Pediatría", "Dermatología", "Traumatología", "Oftalmología" };

    public List<Turno> GetAll(int cantidad = 10)
    {
        var turnos = new List<Turno>();
        var rand = new Random();

        for (int i = 1; i <= cantidad; i++)
        {
            var turno = new Turno()
            {
                Cliente = NombresPacientes[rand.Next(NombresPacientes.Length)]

            };

            turnos.Add(turno);
        }

        return turnos;
    }
}