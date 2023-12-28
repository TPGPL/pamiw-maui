using PamiwShared.Models;
using System.Net.Http.Json;

namespace PamiwMauiApp.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    private readonly AuthInfo _authInfo;

    public BookService(HttpClient httpClient, AuthInfo authInfo)
    {
        _httpClient = httpClient;
        _authInfo = authInfo;
    }

    public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authInfo.Token);
            var response = await _httpClient.GetAsync("books");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Book>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Book>>>()
                ?? new ServiceResponse<List<Book>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Book>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> GetBookAsync(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authInfo.Token);
            var response = await _httpClient.GetAsync($"books/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Book>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> UpdateBookAsync(int id, Book Book)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authInfo.Token);
            var response = await _httpClient.PutAsJsonAsync($"books/{id}", Book);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> CreateBookAsync(Book Book)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authInfo.Token);
            var response = await _httpClient.PostAsJsonAsync($"books", Book);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> DeleteBookAsync(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authInfo.Token);
            var response = await _httpClient.DeleteAsync($"books/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }
}