using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class PublishersView : ContentPage
{
	public PublishersView(PublishersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}