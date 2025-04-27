namespace PS.UI.Maui.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
	}

    private void btnKeep_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.HistoryPage());
    }

    private void btnShare_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.LoadPage());
    }

    private void btnSearch_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.LoadPage());
    }
}