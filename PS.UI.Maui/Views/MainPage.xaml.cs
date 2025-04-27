namespace PS.UI.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void btnContinue_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.LoadPage());
    }
}