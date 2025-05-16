namespace PS.UI.Maui.Views;

public partial class WaitingPage : ContentPage
{
    IServiceProvider _serviceProvider;

    public WaitingPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private void btnResult_Clicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<DetailPage>();
        Navigation.PushAsync(nextPage);
        //Navigation.PushAsync(new Views.DetailPage());
    }
}