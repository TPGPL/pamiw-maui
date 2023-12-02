using System.Text.Json.Serialization;

namespace PamiwMauiApp.Models;

public class UserRegister
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
}
