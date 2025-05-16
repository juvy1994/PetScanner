namespace PS.UI.Maui.Views;

public partial class LoadPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public LoadPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private void btnTakePhoto_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Views.WaitingPage());
    }

    private void btnUploadPhoto_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Views.WaitingPage());
    }

    private void btnSearch_Clicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<WaitingPage>();
        Navigation.PushAsync(nextPage);
        //Navigation.PushAsync(new Views.WaitingPage());
    }

    private void imbTomarFoto_Clicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<WaitingPage>();
        Navigation.PushAsync(nextPage);
       // Navigation.PushAsync(new Views.WaitingPage());
    }

    private void imbSubirImagen_Clicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<WaitingPage>();
        Navigation.PushAsync(nextPage);

        //Navigation.PushAsync(new Views.WaitingPage());
    }
}