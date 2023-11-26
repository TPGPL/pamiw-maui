using CommunityToolkit.Mvvm.Input;
using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class AuthorsView : ContentPage
{

	public AuthorsView(AuthorsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}