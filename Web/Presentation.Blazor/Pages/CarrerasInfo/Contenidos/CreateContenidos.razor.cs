using BlazorStrap.V5;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Components.CarrerasInfo.Contenidos;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Contenidos;

public partial class CreateContenidos
{
    BSModal? modal;
    private ContenidoInfo contenidoInfo { get; set; } = new ContenidoInfo();
    private string modalContent = "";
    private string modalTitle = "";
    private string colorStatus = "";
    private string messageButton1 = "";
    private string messageButton2 = "";
    private bool success = false;

}
