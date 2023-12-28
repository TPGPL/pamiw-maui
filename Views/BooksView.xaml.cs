using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp.Views;

public partial class BooksView : ContentPage
{
    private readonly BooksViewModel _viewModel;

    public BooksView(BooksViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
        Loaded += OnPageLoaded;
    }

    private async void OnPageLoaded(object sender, EventArgs args)
    {
        _viewModel.IsBusy = true;
        await _viewModel.GetBooks();
        _viewModel.IsBusy = false;
    }
}