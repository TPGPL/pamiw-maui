using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
