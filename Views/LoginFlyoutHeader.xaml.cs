namespace PamiwMauiApp.Views;

public partial class LoginFlyoutHeader : ContentView
{
	public LoginFlyoutHeader(string username)
	{
		InitializeComponent();
		loginLabel.Text = username;
	}
}