using BlazorStrap.V5;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Components.CarrerasInfo.Carreras;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class CreateCarrera
{
    BSModal? modal;
    private CarreraInfo carreraInfo { get; set; } = new CarreraInfo();
    private string modalContent = "";
    private string modalTitle = "";
    private string colorStatus = "";
    private string messageButton1 = "";
    private string messageButton2 = "";
    private bool success = false;
}
