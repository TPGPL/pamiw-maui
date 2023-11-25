using System.Text.Json.Serialization;

namespace PamiwMauiApp.Models;

public class ServiceResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("wasSuccessful")]
    public bool Success { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
