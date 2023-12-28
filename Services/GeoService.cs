using PamiwShared.Models;

namespace PamiwMauiApp.Services;

internal class GeoService : IGeoService
{
    public async Task<ServiceResponse<Location>> GetCurrentLocationAsync()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            var location = await Geolocation.Default.GetLocationAsync(request);

            if (location is null)
            {
                return new ServiceResponse<Location>
                {
                    Message = "Failed to get current location.",
                    Success = false
                };
            }

            return new ServiceResponse<Location> {
                Success = true,
                Data = location
            };
        } catch (Exception)
        {
            return new ServiceResponse<Location>
            {
                Message = "Failed to get current location.",
                Success = false
            };
        }
    }
}
