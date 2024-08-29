using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Components;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListCarreras
{
    private async Task UpdateBudgetsAsync()
    {

        // set loading screen while updating budgets
        IsLoadingContents = true;
        StateHasChanged();

        // Set loading screen while updating budgets
        if (_carreras == null)
        {
            IsLoadingContents = true;
            StateHasChanged();
            return;
        }
        foreach (var carrera in _carreras)
        {
            await carrerraService.UpdateCarreraScholarshipBudgetFrontendAsync(carrera.Codigo);
        }
        // Remove loading screen
        await OnInitializedAsync();
        IsLoadingContents = false;
        StateHasChanged();
    }
}
