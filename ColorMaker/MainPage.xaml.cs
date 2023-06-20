using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    private string hexValue;
    private bool isRandom = false;

	public MainPage()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color copied");
        await toast.Show();
    }

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sliderRed.Value;
            var green = sliderGreen.Value;
            var blue = sliderBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            setColor(color);
        }
    }

    private void setColor(Color color)
    {
        container.BackgroundColor = color;
        buttonRandom.BackgroundColor = color;
        labelHex.Text = $"HEX Value: {color.ToHex()}";
        hexValue = color.ToHex();
    }

    private void buttonRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var rand = new Random();
        Color color = Color.FromRgb(
            rand.Next(0, 256),
            rand.Next(0, 256),
            rand.Next(0, 256));

        setColor(color);

        sliderRed.Value = color.Red;
        sliderGreen.Value = color.Green;
        sliderBlue.Value = color.Blue;

        isRandom = false;
    }
}

