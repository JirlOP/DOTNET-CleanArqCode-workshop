using BlazorStrap;
using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class CreateCarrera
{
    private void OnReset(IBSForm bSForm)
    {
        bSForm.Reset();
    }

    private async Task OnSubmit(EditContext e)
    {
        if (e.Validate())
        {
            if (carreraInfo.Codigo != null ||
                carreraInfo.Nombre != null ||
                carreraInfo.Escuela != null)
            {
                Carrera carrera = new Carrera(
                    codigo: Codigo.Create(carreraInfo.Codigo),
                    nombre: Nombre.Create(carreraInfo.Nombre),
                    escuela: Nombre.Create(carreraInfo.Escuela),
                    isSteam: false, // TODO: Change this to a dynamic value
                    presupuestoBecas: Budget.Create(0) // TODO: Change this to a dynamic value
                ); 
                success = await carrerraService.CreateCarreraAsync(carrera);
            }

            if (success)
            {
                modalTitle = "Carrera creada exitosamente!";
                modalContent = "<p>La carrera fue creada exitosamente!</p>";
                colorStatus = "#95B60A;";
                messageButton1 = "Crear otra carrera";
                messageButton2 = "Ir a la lista de carreras";
            }
            else
            {
                modalTitle = "Ha habido un error";
                modalContent = "La carrera no pudo ser creada.\n!El codigo ya existe¡";
                colorStatus = "#B14212;";
                messageButton1 = "Volver a la creación de carrera";
            }
            if (modal != null)
            {
                await modal.ShowAsync();
            }
        }
    }
}
