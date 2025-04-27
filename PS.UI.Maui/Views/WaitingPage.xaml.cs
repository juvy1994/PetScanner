namespace PS.UI.Maui.Views;

public partial class WaitingPage : ContentPage
{
	public WaitingPage()
	{
		InitializeComponent();
	}

    private void btnResult_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.DetailPage());
    }
}