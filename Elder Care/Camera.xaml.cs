using Camera.MAUI.ZXingHelper;
using Elder_Care.Classes;

namespace Elder_Care;

public partial class Camera : ContentPage
{
    DB_Connection conn = new DB_Connection();
    string scanned;

    public Camera()
	{
		InitializeComponent();
	}
    
    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void cameraView_BarcodeDetected(object sender, BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            scanned = args.Result[0].ToString();
            string str = trimString(scanned, conn.Address.Length);

            if (str != conn.Address)
            {
                QRLabel.TextColor = Colors.Red;
                QRLabel.Text = "QR not recognized";
                QRBTN.IsEnabled = false;

            }
            else if (str == conn.Address)
            {
                QRLabel.TextColor = Colors.Green;
                QRLabel.Text = "QR Recognized";
                QRBTN.IsEnabled = true;
            }
            
        });
    }

    private async void searchQR (object sender, EventArgs e)
    {
        Person person = conn.GetPerson(scanned);

        Navigation.PushAsync(new QRSearched(person));
    }

    private string trimString(string str, int maxInt)
    {
        return str.Substring(0, Math.Min(str.Length, maxInt));
    }
}