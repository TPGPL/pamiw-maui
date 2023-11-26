using PamiwMauiApp.Views;

namespace PamiwMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AuthorDetailsView), typeof(AuthorDetailsView));
        }
    }
}
