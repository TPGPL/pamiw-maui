using PamiwMauiApp.ViewModels;
using PamiwMauiApp.Views;

namespace PamiwMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            Routing.RegisterRoute(nameof(AuthorDetailsView), typeof(AuthorDetailsView));
            Routing.RegisterRoute(nameof(NewAuthorView), typeof(NewAuthorView));
            Routing.RegisterRoute(nameof(PublisherDetailsView), typeof(PublisherDetailsView));
            Routing.RegisterRoute(nameof(NewPublisherView), typeof(NewPublisherView));
            Routing.RegisterRoute(nameof(BookDetailsView), typeof(BookDetailsView));
            Routing.RegisterRoute(nameof(NewBookView), typeof(NewBookView));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
        }
    }
}
