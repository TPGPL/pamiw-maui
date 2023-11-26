using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class NewBookView : ContentPage
{
	public NewBookView(NewBookViewModel newBookViewModel)
	{
		BindingContext = newBookViewModel;
		InitializeComponent();
	}
}