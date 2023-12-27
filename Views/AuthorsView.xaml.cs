using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class AuthorsView : ContentPage
{
	private readonly AuthorsViewModel _viewModel;

	public AuthorsView(AuthorsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
		Loaded += OnPageLoaded;
	}

    private async void OnPageLoaded(object sender, EventArgs e)
	{
		await _viewModel.GetAuthors();
	}
}