namespace BlocoDeNotas.App;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void btnSobre_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://github.com/PauloAlves8039");
    }
}