using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class BooksView : ContentPage
{
	public BooksView(BooksViewModel booksViewModel)
	{
		InitializeComponent();
		BindingContext = booksViewModel;
	}
}