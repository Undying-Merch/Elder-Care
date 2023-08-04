namespace Elder_Care;

public partial class MainPage : ContentPage
{
	private bool passHidden = true;

	public MainPage()
	{
		InitializeComponent();

		if (Preferences.Default.ContainsKey("user") == true)  { loginRemember.IsChecked = true; userEntry.Text = Preferences.Default.Get("user", ""); passEntry.Text = Preferences.Default.Get("pass", ""); }
	}

	private void showPass(object sender ,EventArgs e)
	{
		if (passHidden)	{	passBTN.Text = "Hide"; passEntry.IsPassword = false; passHidden = false;	}
		else { passBTN.Text = "Show"; passEntry.IsPassword = true; passHidden = true; }
	}

	private void nextPage(object sender, EventArgs e)
	{
		if (userEntry.Text.ToString() == "jolj" && passEntry.Text.ToString() == "Password")
		{
            if (loginRemember.IsChecked == true)
            {
                Preferences.Default.Set("user", userEntry.Text.ToString());
                Preferences.Default.Set("pass", passEntry.Text.ToString());
            }
            else { Preferences.Default.Remove("user"); Preferences.Default.Remove("pass"); }

			Navigation.PushAsync(new TestPage());
        }
		else
		{
			DisplayAlert("Error", "Incorrect UserName or Password", "OK");
		}
		
		
	}
}

