using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

/// <summary>
/// Contenido entity.
/// </summary>
public class Contenido
{
    public Acronimo Acronimo { get; }

    public Nombre Nombre { get; }

    public Creditos Creditos { get; }

    public TipoContenido Tipo { get; }

    // entity relationship
    public ICollection<Carrera> Carreras { get; } = [];

    public Contenido(Acronimo acronimo, Nombre nombre, Creditos creditos, TipoContenido tipo)
    {
        Acronimo = acronimo;
        Nombre = nombre;
        Creditos = creditos;
        Tipo = tipo;
    }

    // Operators to know the type of content
    public bool IsTecnologico() => Tipo.Value == 't';
    public bool IsSocial() => Tipo.Value == 's';
    public bool IsAmbiental() => Tipo.Value == 'a';
}

