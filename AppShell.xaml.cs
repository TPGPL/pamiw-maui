using PamiwMauiApp.Views;

namespace PamiwMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AuthorDetailsView), typeof(AuthorDetailsView));
            Routing.RegisterRoute(nameof(NewAuthorView), typeof(NewAuthorView));
            Routing.RegisterRoute(nameof(PublisherDetailsView), typeof(PublisherDetailsView));
            Routing.RegisterRoute(nameof(NewPublisherView), typeof(NewPublisherView));
        }
    }
}
