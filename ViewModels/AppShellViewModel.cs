using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwShared.Models;
using PamiwMauiApp.Views;

namespace PamiwMauiApp.ViewModels;

public partial class AppShellViewModel : ObservableObject
{
    private readonly UserInfo _userInfo;

    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public AppShellViewModel(UserInfo userInfo, LocalizationResourceManager localizationResourceManager)
    {
        _userInfo = userInfo;
        this.localizationResourceManager = localizationResourceManager;
    }

    [RelayCommand]
    public async Task SignOut()
    {
        _userInfo.Authenticated = false;
        _userInfo.Token = string.Empty;
        _userInfo.Username = string.Empty;

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    [RelayCommand]
    public async Task Settings()
    {
        await Shell.Current.GoToAsync(nameof(SettingsView));
    }
}
