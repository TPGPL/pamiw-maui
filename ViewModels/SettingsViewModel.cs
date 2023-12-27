using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace PamiwMauiApp.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    [ObservableProperty]
    AppTheme selectedTheme = Application.Current.RequestedTheme;

    [ObservableProperty]
    string selectedLanguage = "Polish";

    [ObservableProperty]
    ObservableCollection<string> languages = ["Polish", "English"];

    [ObservableProperty]
    ObservableCollection<AppTheme> themes = [AppTheme.Dark, AppTheme.Light];

    public SettingsViewModel()
    {
        Title = "Settings";
    }

    [RelayCommand]
    public void SaveChanges()
    {
        Application.Current.UserAppTheme = SelectedTheme;
    }
}
