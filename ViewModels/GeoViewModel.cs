using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.Components;
using PamiwMauiApp.Services;

namespace PamiwMauiApp.ViewModels;

public partial class GeoViewModel : BaseViewModel
{
    private readonly IGeoService geoService;
    private readonly MauiMessageDialogService messageDialogService;

    [ObservableProperty]
    LocalizationResourceManager localizationResourceManager;

    [ObservableProperty]
    string altitudeText = "-";

    [ObservableProperty]
    string latitudeText = "-";

    [ObservableProperty]
    string longitudeText = "-";

    public GeoViewModel(LocalizationResourceManager localizationResourceManager, IGeoService geoService, MauiMessageDialogService messageDialogService)
    {
        this.localizationResourceManager = localizationResourceManager;
        this.geoService = geoService;
        this.messageDialogService = messageDialogService;
    }

    [RelayCommand]
    public async Task Get()
    {
        IsBusy = true;

        var response = await geoService.GetCurrentLocationAsync();

        if (!response.Success)
        {
            messageDialogService.ShowMessage((string)LocalizationResourceManager["GeoFail"]);
        }

        AltitudeText = response?.Data?.Altitude.ToString() ?? "-";
        LatitudeText = response?.Data?.Latitude.ToString() ?? "-";
        LongitudeText = response?.Data?.Longitude.ToString() ?? "-";

        IsBusy = false;
    }
}
