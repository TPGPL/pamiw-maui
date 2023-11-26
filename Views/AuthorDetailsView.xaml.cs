using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class AuthorDetailsView : ContentPage
{
	public AuthorDetailsView(AuthorDetailsViewModel authorDetailsViewModel)
	{
		BindingContext = authorDetailsViewModel;
		InitializeComponent();
	}
}