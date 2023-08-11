namespace Elder_Care;
using Classes;

public partial class Personel_Overview : ContentPage
{
	List<String> locationList = new List<String>();
	List<String> personelList = new List<String>();
	List<Personel> personels = new List<Personel>();
	List<institution> institutions = new List<institution>();
	DB_Connection conn = new DB_Connection();

    public Personel_Overview()
	{
		InitializeComponent();
		institutions = conn.getAllInstitution();
        personels = conn.getAllPersonel();

		for (int i = 0; i < institutions.Count; i++)
		{
			locationList.Add(institutions[i].navn);
		}
		locationPicker.ItemsSource = locationList;
	}

	private void onlocationListChanged (object sender, EventArgs e)
	{
		personelList.Clear();
		if (personPicker.IsEnabled == false)
		{
			personPicker.IsEnabled = true;
		}
		if (personPicker.ItemsSource != null)
		{
			personPicker.ItemsSource.Clear();
			personPicker.ItemsSource=null;
		}
		int locationId = -1;
		int pickerid = locationPicker.SelectedIndex;
		for (int i = 0;i < institutions.Count; i++)
		{
			if (locationPicker.Items[pickerid] == institutions[i].navn)
			{
				locationId = institutions[i].id;
			}
		}
		for (int i = 0;i < personels.Count;i++)
		{
			if (personels[i].institution == locationId)
			{
				personelList.Add(personels[i].navn);
			}
		}
		personPicker.ItemsSource = personelList;

	}

	private void onPersonListChanged(object sender, EventArgs e)
	{
		if (callBTN.IsEnabled == false)
		{
			callBTN.IsEnabled = true;
		}
	}
}