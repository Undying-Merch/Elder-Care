using Elder_Care.Classes;

namespace Elder_Care;

public partial class QRSearched : ContentPage
{
	Person patient = new Person();
	DB_Connection conn = new DB_Connection();
    List<institution> institutions = new List<institution>();

    public QRSearched()
	{
		InitializeComponent();
	}
	public QRSearched(Person broughtPerson)
	{
		InitializeComponent();
		patient = broughtPerson;
		nameLabel.Text = nameLabel.Text + broughtPerson.navn;
		birthLabel.Text = birthLabel.Text + broughtPerson.fodselsdag.ToString();
        institutions = conn.getAllInstitution();
		for (int i = 0; i < institutions.Count; i++)
		{
			if (institutions[i].id == patient.institutionId)
			{
				institutionLabel.Text = institutionLabel.Text + institutions[i].navn;
				phoneLabel.Text = phoneLabel.Text + institutions[i].telefon;
			}
		}

    }

	private void callInst(object sender, EventArgs e)
	{
        for (int i = 0; i < institutions.Count; i++)
        {
            if (institutions[i].id == patient.institutionId)
            {
                if (PhoneDialer.Default.IsSupported)
                {
					PhoneDialer.Default.Open(institutions[i].telefon.ToString());
                }
                else
                {
                    DisplayAlert("Error", "Phone Dialer not supported", "OK");
                }
            }
        }
    }
}