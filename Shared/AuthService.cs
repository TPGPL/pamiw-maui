using PamiwMauiApp.Models;
using System.Net.Http.Json;

namespace pamiw_pwa.Services;

public class AuthService : IAuthService
{
    private UserInfo _userInfo;
    private HttpClient _httpClient;

    public AuthService(HttpClient httpClient, UserInfo userInfo)
    {
        _httpClient = httpClient;
        _userInfo = userInfo;
    }

    public async Task<ServiceResponse<string>> LoginAsync(UserLogin user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", user);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = message is not null && message.Any() ? message : "Invalid user credentials."
                };
            }

            var token = await response.Content.ReadAsStringAsync();

            if (token != string.Empty)
            {
                _userInfo.Authenticated = true;
                _userInfo.Username = user.Username;
                _userInfo.Token = token;
            }

            return new ServiceResponse<string>()
            {
                Success = true,
                Data = token
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = ex.Message ?? "Failed to login."
            };
        }
    }

    public async Task<ServiceResponse<string>> RegisterAsync(UserRegister user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", user);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = message is not null && message.Any() ? message : "Invalid user data."
                };
            }

            var mess = await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string>()
            {
                Success = true,
                Message = mess
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = ex.Message ?? "Failed to login."
            };
        }
    }
}
