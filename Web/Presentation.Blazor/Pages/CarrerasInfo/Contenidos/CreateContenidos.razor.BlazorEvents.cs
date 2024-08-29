using BlazorStrap;
using Microsoft.AspNetCore.Components.Forms;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Contenidos;

public partial class CreateContenidos
{
    private void OnReset(IBSForm bSForm)
    {
        bSForm.Reset();
    }


    private async Task OnSubmit(EditContext e)
    {
        if (e.Validate())
        {

            Contenido contenido = new Contenido(
                acronimo: Acronimo.Create(contenidoInfo.acronimo),
                nombre: Nombre.Create(contenidoInfo.nombre),
                creditos: Creditos.Create(contenidoInfo.creditos),
                tipo: TipoContenido.Create('o') // TODO: Change this to a dynamic value
            );

            success = await contenidoService.CreateContenidosAsync(contenido);
            if (success)
            {
                modalTitle = "Contenido creado exitosamente!";
                modalContent = "<p>El contenido fue creado exitosamente!</p>";
                colorStatus = "#95B60A;";
                messageButton1 = "Crear otro contenido";
                messageButton2 = "Ir a la lista de contenidos";
            }
            else
            {
                modalTitle = "Ha habido un error";
                modalContent = "El contenido no pudo ser creado.\n¡El acronimo ya existe!";
                colorStatus = "#B14212;";
                messageButton1 = "Volver a la creación de contenido";
            }
            await modal.ShowAsync();
        }
    }
}
