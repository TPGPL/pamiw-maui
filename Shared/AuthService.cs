using PamiwShared.Models;
using System.Net.Http.Json;

namespace PamiwMauiApp.Services;

public class AuthService : IAuthService
{
    private AuthInfo _authInfo;
    private HttpClient _httpClient;

    public AuthService(HttpClient httpClient, AuthInfo authInfo)
    {
        _httpClient = httpClient;
        _authInfo = authInfo;
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
                _authInfo.Authenticated = true;
                _authInfo.Username = user.Username;
                _authInfo.Token = $"{token}";

                _authInfo.Update();
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
                Message = serviceResponse?.Message ?? "User registered successfully."
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
