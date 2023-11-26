using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class PublisherDetailsView : ContentPage
{
	public PublisherDetailsView(PublisherDetailsViewModel publisherDetailsViewModel)
	{
		BindingContext = publisherDetailsViewModel;
		InitializeComponent();
	}
}