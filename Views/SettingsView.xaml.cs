using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}