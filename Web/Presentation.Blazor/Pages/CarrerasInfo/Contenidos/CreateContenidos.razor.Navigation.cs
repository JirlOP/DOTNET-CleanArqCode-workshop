namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Contenidos;

public partial class CreateContenidos
{
    private void NavigateToCreateContenido()
    {
        if (modal != null)
        {
            modal.HideAsync();
        }
        navigationManager.NavigateTo("/CreateContenidos");
    }
}
