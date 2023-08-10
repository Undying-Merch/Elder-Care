namespace Elder_Care;
using Classes;

public partial class Personel_Overview : ContentPage
{
	List<String> locationList = new List<String>();
	List<Personel> personels = new List<Personel>();
	List<institution> institutions = new List<institution>();
	DB_Connection conn = new DB_Connection();

	private void setLocations()
	{
		locationList.Add("Loaction 1");
        locationList.Add("Loaction 2");
        locationList.Add("Loaction 3");
		locationPicker.ItemsSource = locationList;
    }

    public Personel_Overview()
	{
		InitializeComponent();
		setLocations();
		personels = conn.getAllPersonel();
		institutions = conn.getAllInstitution();
	}

	private void onlocationListChanged (object sender, EventArgs e)
	{
		if (personPicker.IsEnabled == false)
		{
			personPicker.IsEnabled = true;
		}
	}

	private void onPersonListChanged(object sender, EventArgs e)
	{
		if (callBTN.IsEnabled == false)
		{
			callBTN.IsEnabled = true;
		}
	}
}