using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class BookDetailsView : ContentPage
{
	public BookDetailsView(BookDetailsViewModel bookDetailsViewModel)
	{
		BindingContext = bookDetailsViewModel;
		InitializeComponent();
	}
}