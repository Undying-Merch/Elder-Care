namespace Elder_Care;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

	private async void gotoQR(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Camera());
    }

	private void gotoPersonalOverview(object  sender, EventArgs e)
	{
		Navigation.PushAsync( new Personel_Overview() );
	}
}