using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Resources.Strings;
using System.Collections.ObjectModel;
using System.Globalization;

namespace PamiwMauiApp.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    [ObservableProperty]
    AppTheme selectedTheme = Application.Current.RequestedTheme;

    [ObservableProperty]
    string selectedLanguage = AppResources.Culture.NativeName;

    [ObservableProperty]
    ObservableCollection<string> languages = [CultureInfo.GetCultureInfo("pl-PL").NativeName, CultureInfo.GetCultureInfo("en-US").NativeName];

    [ObservableProperty]
    ObservableCollection<AppTheme> themes = [AppTheme.Dark, AppTheme.Light];

    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public SettingsViewModel(LocalizationResourceManager localizationResourceManager)
    {
        this.localizationResourceManager = localizationResourceManager;
    }

    [RelayCommand]
    public void SaveChanges()
    {
        Application.Current.UserAppTheme = SelectedTheme;

        LocalizationResourceManager.SetCulture(SelectedLanguage switch
        {
            "polski (Polska)" => CultureInfo.GetCultureInfo("pl-PL"),
            "English (United States)" => CultureInfo.GetCultureInfo("en-US"),
            _ => CultureInfo.GetCultureInfo("en-US")
        });
    }
}
