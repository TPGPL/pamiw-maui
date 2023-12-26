using PamiwShared.Models;

namespace PamiwMauiApp.Services;

public interface IAuthService
{
    Task<ServiceResponse<string>> LoginAsync(UserLogin user);
    Task<ServiceResponse<string>> RegisterAsync(UserRegister user);
}
