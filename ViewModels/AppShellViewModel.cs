using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Views;

namespace PamiwMauiApp.ViewModels;

public partial class AppShellViewModel : ObservableObject
{
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    [ObservableProperty]
    AuthInfo authInfo;

    public AppShellViewModel(LocalizationResourceManager localizationResourceManager, AuthInfo authInfo)
    {
        this.localizationResourceManager = localizationResourceManager;
        this.authInfo = authInfo;
    }

    [RelayCommand]
    public async Task SignOut()
    {
        AuthInfo.Authenticated = false;
        AuthInfo.Token = string.Empty;
        AuthInfo.Username = string.Empty;

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    [RelayCommand]
    public async Task Settings()
    {
        await Shell.Current.GoToAsync(nameof(SettingsView));
    }
}
