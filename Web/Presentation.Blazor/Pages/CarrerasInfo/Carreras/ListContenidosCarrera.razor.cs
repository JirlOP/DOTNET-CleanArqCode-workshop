using BlazorStrap.V5;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListContenidosCarrera
{
    // HTML attributes
    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;

    string codigoCarreraString = "";
    string nombreCarreraString = "";
    string escuelaCarreraString = "";
    string isSteamString = "";
    string presupuestoCarreraString = "";

    Codigo codigocarrera = null!;
    string acronimoContenidoAñadido = "";

    BSModal? modal;
    string model = "";


    // List of carreras
    private IEnumerable<Contenido>? _contenidosCarrera = null;
    private IEnumerable<Contenido>? _contenidos = null;

    private IEnumerable<string> _acronimoContenidosCarrera = new List<string>();
    private IEnumerable<string> _acronimoContenidos = new List<string>();
    private IEnumerable<string> _acronimoContenidosAdicionales = new List<string>();

}
