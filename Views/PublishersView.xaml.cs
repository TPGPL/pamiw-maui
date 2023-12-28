using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class PublishersView : ContentPage
{
	private readonly PublishersViewModel _viewModel;

	public PublishersView(PublishersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
		Loaded += OnPageLoaded;
	}

	private async void OnPageLoaded(object sender, EventArgs args)
	{
		_viewModel.IsBusy = true;
		await _viewModel.GetPublishers();
		_viewModel.IsBusy = false;
	}
}