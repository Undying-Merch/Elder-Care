using Camera.MAUI.ZXingHelper;

namespace Elder_Care;

public partial class Camera : ContentPage
{
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
            QRLabel.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
        });
    }

}