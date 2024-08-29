using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories
{
    public class ExternalRegisterCarreraInfoRepository : IExternalRegisterCarreraInfoRepository
    {

        // Facade to the external register
        private readonly Dictionary<string, double>_womenPercentages;

        /// <summary>
        /// Sample data to not depend on the external register
        /// </summary>
        public ExternalRegisterCarreraInfoRepository()
        {
            _womenPercentages = new Dictionary<string, double>()
            {
                { "340301", 0.6 },
                { "341001", 0.3 },
                { "420705", 0.7 },
                { "507024", 0.4 },
                { "600123", 0.4 },
            };

        }

        /// <summary>
        /// Just for testing purposes. 
        /// </summary>
        /// <param name="carrera"></param>
        /// <remarks>
        /// This method should be implemented in the future
        /// </remarks>
        /// <returns></returns>
        public async Task<Percentage> GetWomenPercentageAsync(Codigo codigo)
        {
            if (_womenPercentages.TryGetValue(codigo.Value, out double percentage))
            {
                return await Task.FromResult(Percentage.Create(percentage));
            }

            // If not found, return 0%
            return await Task.FromResult(Percentage.Create(0.0));
        }
    }
}
