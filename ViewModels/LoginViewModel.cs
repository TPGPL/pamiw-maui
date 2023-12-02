using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Models;
using PamiwMauiApp.Views;

namespace PamiwMauiApp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        UserLogin user;

        [RelayCommand]
        public void Login()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }

        [RelayCommand]
        public async Task Register()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
