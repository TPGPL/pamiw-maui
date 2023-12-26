using PamiwShared.Models;
using System.Net.Http.Json;

namespace PamiwMauiApp.Services;

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
            var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<JwtResponse>>();

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = serviceResponse?.Message ?? "Invalid user credentials."
                };
            }

            var token = serviceResponse?.Data?.Token;

            if (token is not null)
            {
                _userInfo.Authenticated = true;
                _userInfo.Username = user.Username;
                _userInfo.Token = $"{token}";
            }

            return new ServiceResponse<string>()
            {
                Success = true,
                Data = token
            };
        }
        catch (Exception)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = "Failed to login."
            };
        }
    }

    public async Task<ServiceResponse<string>> RegisterAsync(UserRegister user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", user);
            var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = serviceResponse?.Message ?? "Failed to register."
                };
            }

            return new ServiceResponse<string>()
            {
                Success = true,
                Message = serviceResponse?.Message ?? "Invalid user credentials"
            };
        }
        catch (Exception)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = "Failed to register."
            };
        }
    }
}
