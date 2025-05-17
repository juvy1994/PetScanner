using System.Net.Http.Headers;
using System.Text.Json;


namespace PS.UI.Maui.Views;

public partial class LoadPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private FileResult _fotoSeleccionada;

    public LoadPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();

        _serviceProvider = serviceProvider;

    }

    private async void btnSearch_Clicked(object sender, EventArgs e)
    {
        if (_fotoSeleccionada == null)
        {
            await DisplayAlert("Advertencia", "Primero selecciona una foto.", "OK");
            return;
        }

        var nextPage = _serviceProvider.GetRequiredService<WaitingPage>();
        nextPage.FotoParaEnviar = _fotoSeleccionada;
        await Navigation.PushAsync(nextPage);
    }

    private async void OnTomarFotoClicked(object sender, EventArgs e)
    {
        if (!await PedirPermisosAsync()) return;
        var foto = await MediaPicker.Default.CapturePhotoAsync();
        if (foto == null) return;

        _fotoSeleccionada = foto;
        var stream = await foto.OpenReadAsync();
        FotoImage.Source = ImageSource.FromStream(() => stream);
    }

    private async void OnSubirDesdeGaleriaClicked(object sender, EventArgs e)
    {
        var status = await Permissions.RequestAsync<Permissions.Photos>();
        if (status != PermissionStatus.Granted)
        {
            await DisplayAlert("Permiso denegado", "Se necesita acceso a las fotos.", "OK");
            return;
        }

        var foto = await MediaPicker.Default.PickPhotoAsync();
        if (foto == null)
            return;
        _fotoSeleccionada = foto;
        var stream = await foto.OpenReadAsync();
        FotoImage.Source = ImageSource.FromStream(() => stream);
    }

    async Task<bool> PedirPermisosAsync()
    {
        var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
        var photoStatus = await Permissions.RequestAsync<Permissions.Photos>();

        return cameraStatus == PermissionStatus.Granted && photoStatus == PermissionStatus.Granted;
    }
}