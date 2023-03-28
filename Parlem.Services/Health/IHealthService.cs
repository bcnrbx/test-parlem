namespace Parlem.Services.Health
{
    public interface IHealthService
    {
        Task<string> GetHealthStatusAsync();
    }
}
