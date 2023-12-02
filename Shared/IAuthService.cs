using PamiwMauiApp.Models;

namespace pamiw_pwa.Services;

public interface IAuthService
{
    Task<ServiceResponse<string>> LoginAsync(UserLogin user);
    Task<ServiceResponse<string>> RegisterAsync(UserRegister user);
}
