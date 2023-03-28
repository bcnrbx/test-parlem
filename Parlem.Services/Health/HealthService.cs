namespace Parlem.Services.Health
{
    public class HealthService : IHealthService
    {
        public async Task<string> GetHealthStatusAsync()
        {
            return await Task.FromResult("Up and running!");
        }
    }
}
