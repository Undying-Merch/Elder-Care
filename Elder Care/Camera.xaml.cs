using Camera.MAUI.ZXingHelper;
using static System.Net.WebRequestMethods;

namespace Elder_Care;

public partial class Camera : ContentPage
{
    private string addressString = "http://192.168.1.148";


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
            string scanned = args.Result[0].ToString();
            string str = trimString(scanned, addressString.Length);

            if (str != addressString)
            {
                QRLabel.TextColor = Colors.Red;
                QRLabel.Text = "QR not recognized";
                QRBTN.IsEnabled = false;

            }
            else if (str == addressString)
            {
                QRLabel.TextColor = Colors.Green;
                QRLabel.Text = "QR Recognized";
                QRBTN.IsEnabled = true;
            }
            
            //QRLabel.Text = args.Result[0].Text;
        });
    }

    private string trimString(string str, int maxInt)
    {
        return str.Substring(0, Math.Min(str.Length, maxInt));
    }
}