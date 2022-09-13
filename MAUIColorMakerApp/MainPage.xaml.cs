using CommunityToolkit.Maui.Alerts;

namespace MAUIColorMakerApp;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

	private void sldValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandom)
		{
            var Red = sldRed.Value;
            var Green = sldGreen.Value;
            var Blue = sldBlue.Value;

            Color color = Color.FromRgb(Red, Green, Blue);
            SetColor(color);
        }
		

		
	}

	private void SetColor(Color color)
	{
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		hexValue = color.ToHex();
		lblHex.Text = "HEX Değeri: " + hexValue;

    }

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRandom = true;
		var random = new Random();

		var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
		
		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;
        isRandom = false;
    }

	private async void btnCopy_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(hexValue);

		var toast = Toast.Make("Hex kodu kopyalandı.", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
		await toast.Show();
	}
}

