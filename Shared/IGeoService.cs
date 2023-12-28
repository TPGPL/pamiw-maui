using PamiwShared.Models;

namespace PamiwMauiApp.Shared;

public interface IGeoService
{
    Task<ServiceResponse<Location>> GetCurrentLocationAsync();
}
