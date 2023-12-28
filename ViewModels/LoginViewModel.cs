using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwShared.Services;
using PamiwMauiApp.Components;
using PamiwShared.Models;
using PamiwMauiApp.Views;

namespace PamiwMauiApp.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly MauiMessageDialogService _messageDialogService;
    private readonly IAuthService _authService;
    private readonly HttpClient _httpClient;
    private readonly AuthInfo _authInfo;

    [ObservableProperty]
    UserLogin user = new UserLogin();

    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public LoginViewModel(MauiMessageDialogService messageDialogService, IAuthService authService, LocalizationResourceManager localizationResourceManager, HttpClient httpClient, AuthInfo authInfo)
    {
        _messageDialogService = messageDialogService;
        _authService = authService;
        this.localizationResourceManager = localizationResourceManager;
        _httpClient = httpClient;
        _authInfo = authInfo;
    }

    [RelayCommand]
    public async Task Login()
    {
        var userData = new UserLogin()
        {
            Username = User.Username,
            Password = User.Password,
            ConfirmPassword = User.ConfirmPassword
        };

        IsBusy = true;

        var response = await _authService.LoginAsync(userData);

        IsBusy = false;

        if (!response.Success)
        {
            _messageDialogService.ShowMessage(response.Message ?? "Failed to login.");
            return;
        }

        _authInfo.Username = User.Username;
        _authInfo.Authenticated = true;
        _authInfo.Token = response.Data;

        _authInfo.Update();

        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authInfo.Token);

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
    }

    [RelayCommand]
    public async Task Register()
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}
