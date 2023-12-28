using PamiwShared.Models;

namespace PamiwMauiApp.Services;

public interface IGeoService
{
    Task<ServiceResponse<Location>> GetCurrentLocationAsync();
}
