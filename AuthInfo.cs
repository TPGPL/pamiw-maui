using System.ComponentModel;

namespace PamiwMauiApp;

public class AuthInfo : INotifyPropertyChanged
{
    public string Username { get; set; }
    public string Token { get; set; }
    public bool Authenticated { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Update()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
