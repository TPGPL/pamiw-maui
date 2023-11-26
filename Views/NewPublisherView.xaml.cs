using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class NewPublisherView : ContentPage
{
	public NewPublisherView(NewPublisherViewModel newPublisherViewModel)
	{
		BindingContext = newPublisherViewModel;
		InitializeComponent();
	}
}