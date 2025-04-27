namespace PS.UI.Maui.Views;

public partial class LoadPage : ContentPage
{
	public LoadPage()
	{
		InitializeComponent();
	}

    private void btnTakePhoto_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.WaitingPage());
    }

    private void btnUploadPhoto_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.WaitingPage());
    }

    private void btnSearch_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.WaitingPage());
    }
}