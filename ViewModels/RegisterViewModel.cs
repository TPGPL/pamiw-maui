using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwShared.Services;
using PamiwMauiApp.Components;
using PamiwShared.Models;

namespace PamiwMauiApp.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly MauiMessageDialogService _messageDialogService;
    private readonly IAuthService _authService;

    [ObservableProperty]
    UserRegister user = new UserRegister();

    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public RegisterViewModel(MauiMessageDialogService messageDialogService, IAuthService authService, LocalizationResourceManager localizationResourceManager)
    {
        _messageDialogService = messageDialogService;
        _authService = authService;
        this.localizationResourceManager = localizationResourceManager;
    }

    [RelayCommand]
    public async Task Register()
    {
        var newUser = new UserRegister()
        {
            Username = User.Username,
            Email = User.Email,
            Password = User.Password
        };

        var response = await _authService.RegisterAsync(newUser);

        if (response.Message is not null && response.Message.Any())
        {
            _messageDialogService.ShowMessage(response.Message);
        }

        if (response.Success)
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
