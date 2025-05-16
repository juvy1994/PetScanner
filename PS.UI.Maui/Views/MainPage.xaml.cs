namespace PS.UI.Maui.Views;

public partial class MainPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public MainPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private void btnContinue_Clicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<LoadPage>();
        Navigation.PushAsync(nextPage);
        //Navigation.PushAsync(new Views.LoadPage());
    }
}