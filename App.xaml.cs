using PamiwMauiApp.ViewModels;

namespace PamiwMauiApp
{
    public partial class App : Application
    {
        public App(AppShellViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new AppShell(viewModel);
        }
    }
}
