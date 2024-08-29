namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class CreateCarrera
{
    private void NavigateToCreateCarrera()
    {
        navigationManager.NavigateTo("/CreateCarrera");
        if (modal != null)
        {
            modal.HideAsync();
        }
    }

    private void NavigateToListCarreras()
    {
        navigationManager.NavigateTo("/ListCarreras");
    }
}
