using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class NewAuthorView : ContentPage
{
	public NewAuthorView(NewAuthorViewModel newAuthorViewModel)
	{
		BindingContext = newAuthorViewModel;
		InitializeComponent();
	}
}