using CommunityToolkit.Mvvm.ComponentModel;

namespace PamiwMauiApp.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    public MainPageViewModel(LocalizationResourceManager localizationResourceManager)
    {
        this.localizationResourceManager = localizationResourceManager;
    }
}
