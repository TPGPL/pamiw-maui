using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using pamiw_pwa.Services;
using PamiwMauiApp.Components;
using PamiwMauiApp.Models;
using PamiwMauiApp.Views;

namespace PamiwMauiApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly MauiMessageDialogService _messageDialogService;
        private readonly IAuthService _authService;

        [ObservableProperty]
        UserLogin user = new UserLogin();

        public LoginViewModel(MauiMessageDialogService messageDialogService, IAuthService authService)
        {
            _messageDialogService = messageDialogService;
            _authService = authService;
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

            var response = await _authService.LoginAsync(userData);

            if (!response.Success)
            {
                _messageDialogService.ShowMessage(response.Message ?? "Failed to login.");
                return;
            }

            Shell.Current.FlyoutHeader = new LoginFlyoutHeader(User.Username);

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}", true);
        }

        [RelayCommand]
        public async Task Register()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
