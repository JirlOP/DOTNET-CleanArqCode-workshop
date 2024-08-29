using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;

public class CarreraBudgetCalculatorCoreService : ICarreraBudgetCalculatorCoreService
{


    /// <summary>
    /// Calculate the budget for a Carrera based on Contenidos and student percentage
    /// </summary>
    /// <param name="carrera"></param>
    /// <param name="womenPercentage"></param>
    /// <remarks>
    /// Base Budget is 
    /// </remarks>
    /// <returns></returns>
    public Budget CalculateCarreraScholarshipBudget(
        Percentage womenPercentage,
        Carrera carrera, 
        IEnumerable<Contenido> contenidos)
    {

        // calculate the budget
        double baseBudget = 0;
        double basePercentage = 0;
        double cumulativePercentage = 0;

        // Point 1: donate 100 dolars for each Contenido, 
        foreach (var contenido in contenidos)
        {
            baseBudget += 100;
            // donate 100 dolars extra if is tecnologico
            if (contenido.IsTecnologico())
            {
                baseBudget += 100;
            }
        }

        // Point 2: 50% aditional in base donation if is STEAM if not 20%
        if (carrera.IsSteam)
        {
            basePercentage += 0.5;
        }
        else
        {
            basePercentage += 0.2;
        }
        
        // Point 4: if there are more than 50% women, donate 10% extra in base budget
        if (womenPercentage.Value > 0.5)
        {
            basePercentage += 0.1;
        }

        baseBudget = baseBudget + (baseBudget * basePercentage);

        // now the base is calculated, we calculate the cumulative budget
        double cumulativeBudget = baseBudget;

        // Point 3: 10% aditional cumulative if is STEAM
        if (carrera.IsSteam)
        {
            cumulativePercentage += 0.1;
        }

        // Point 4: if there are more than 50% women, donate 8% extra in cumulative budget if is STEAM
        if (womenPercentage.Value > 0.5 && carrera.IsSteam)
        {
            cumulativePercentage += 0.08;
        }


        // Point 5: 5% aditional cumulative if is from Escuela de Computación
        if (carrera.Escuela.Value.Contains("Computación"))
        {
            cumulativePercentage += 0.05;
        }

        cumulativeBudget = cumulativeBudget + (cumulativeBudget * cumulativePercentage);

        Budget budget = Budget.Create(cumulativeBudget);

        return budget;
    }
}
