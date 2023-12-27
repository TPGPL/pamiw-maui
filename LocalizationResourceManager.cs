using PamiwMauiApp.Resources.Strings;
using System.ComponentModel;
using System.Globalization;

namespace PamiwMauiApp;

public class LocalizationResourceManager : INotifyPropertyChanged
{
    public LocalizationResourceManager()
    {
        AppResources.Culture = CultureInfo.GetCultureInfo("pl-PL");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public object this[string resourceKey] => AppResources.ResourceManager.GetObject(resourceKey, AppResources.Culture) ?? Array.Empty<byte>();

    public void SetCulture(CultureInfo culture)
    {
        AppResources.Culture = culture;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
