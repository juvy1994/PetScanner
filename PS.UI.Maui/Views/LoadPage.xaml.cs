using System.Net.Http.Headers;
using System.Text.Json;


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

    //DESDE AQUI MIS FUNCIONES PARA TOMAR Y SUBIR//
    private async void OnTomarFotoClicked(object sender, EventArgs e)
    {
        if (!await PedirPermisosAsync())
            return;

        var foto = await MediaPicker.Default.CapturePhotoAsync();
        if (foto == null)
            return;

        var stream = await foto.OpenReadAsync();
        FotoImage.Source = ImageSource.FromStream(() => stream);

        string resultado = await EnviarFotoAApi(foto);
        //ResultadoLabel.Text = resultado;
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

        var stream = await foto.OpenReadAsync();
        FotoImage.Source = ImageSource.FromStream(() => stream);

        string resultado = await EnviarFotoAApi(foto);
        // ResultadoLabel.Text = resultado; //aqui vamos a cargar el consumo del jason
    }

    async Task<bool> PedirPermisosAsync()
    {
        var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
        var photoStatus = await Permissions.RequestAsync<Permissions.Photos>();

        return cameraStatus == PermissionStatus.Granted && photoStatus == PermissionStatus.Granted;
    }

    async Task<string> EnviarFotoAApi(FileResult foto)
    {
        try
        {
            using var stream = await foto.OpenReadAsync();
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            content.Add(fileContent, "file", foto.FileName);

            // Reemplaza esta URL por tu API real
            //var response = await client.PostAsync("https://tu-api.com/endpoint", content);//consulta url ejemplo
            var response = await client.PostAsync("https://petscan-hkbtgngtbecxf5ag.centralus-01.azurewebsites.net/api/pets/scan", content);// urg produccion proyecto

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonSerializer.Deserialize<ResultadoApi>(json);

                if (resultado != null)
                {
                    return $"Nombre: {resultado.Nombre}\n" +
                           $"Categoría: {resultado.Categoria}\n" +
                           $"Confianza: {resultado.Confianza * 100:0}%";
                }

                return "Respuesta no entendida.";
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }
        catch (Exception ex)
        {
            return $"Error al enviar la imagen: {ex.Message}";
        }
    }

    // Clase para mapear el JSON
    public class ResultadoApi
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Confianza { get; set; }
    }






}