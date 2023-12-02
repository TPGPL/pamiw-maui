using PamiwMauiApp.Models;
using System.Net.Http.Json;

namespace PamiwMauiApp.Services;

public class AuthorService : IAuthorService
{
    private readonly HttpClient _httpClient;
    private readonly UserInfo _userInfo;

    public AuthorService(HttpClient httpClient, UserInfo userInfo)
    {
        _httpClient = httpClient;
        _userInfo = userInfo;
    }

    public async Task<ServiceResponse<List<Author>>> GetAuthorsAsync()
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.GetAsync("authors");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Author>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Author>>>()
                ?? new ServiceResponse<List<Author>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Author>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occured."
            };
        }
    }

    public async Task<ServiceResponse<Author>> GetAuthorAsync(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.GetAsync($"authors/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Author>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Author>> UpdateAuthorAsync(int id, Author author)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.PutAsJsonAsync($"authors/{id}", author);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Author>> CreateAuthorAsync(Author author)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.PostAsJsonAsync($"authors", author);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Author>> DeleteAuthorAsync(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.DeleteAsync($"authors/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Author>>()
                ?? new ServiceResponse<Author>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Author>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }
}