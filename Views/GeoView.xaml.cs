using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class GeoView : ContentPage
{
	public GeoView(GeoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}