﻿using PamiwShared.Models;
using System.Net.Http.Json;

namespace PamiwMauiApp.Services;

public class PublisherService : IPublisherService
{
    private readonly HttpClient _httpClient;
    private readonly UserInfo _userInfo;

    public PublisherService(HttpClient httpClient, UserInfo userInfo)
    {
        _httpClient = httpClient;
        _userInfo = userInfo;
    }

    public async Task<ServiceResponse<List<Publisher>>> GetPublishersAsync()
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.GetAsync("publishers");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Publisher>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Publisher>>>()
                ?? new ServiceResponse<List<Publisher>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Publisher>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Publisher>> GetPublisherAsync(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.GetAsync($"publishers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Publisher>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
                ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Publisher>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Publisher>> UpdatePublisherAsync(int id, Publisher author)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.PutAsJsonAsync($"publishers/{id}", author);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
                ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Publisher>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Publisher>> CreatePublisherAsync(Publisher author)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.PostAsJsonAsync($"publishers", author);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
                ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Publisher>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Publisher>> DeletePublisherAsync(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _userInfo.Token);
            var response = await _httpClient.DeleteAsync($"publishers/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
                ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Publisher>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }
}