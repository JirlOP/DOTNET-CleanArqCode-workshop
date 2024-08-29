using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

/// <summary>
/// Carrera entity.
/// </summary>
public class Carrera
{
    public Codigo Codigo { get; }

    public Nombre Nombre { get; }

    public Nombre Escuela { get; }

    // default value is false
    public bool IsSteam { get; } = false;

    // can be null if the carrera does not have a budget yet
    public Budget PresupuestoBecas { get; set; }

    // entity relationship
    public ICollection<Contenido> Contenidos { get; } = [];

    public Carrera(Codigo codigo, Nombre nombre, Nombre escuela, bool isSteam, Budget presupuestoBecas)
    {
        Codigo = codigo;
        Nombre = nombre;
        Escuela = escuela;
        IsSteam = isSteam;
        PresupuestoBecas = presupuestoBecas;
    }
}
