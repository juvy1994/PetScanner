
using PS.UI.Maui.Services;
using PS.UI.Maui.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PS.UI.Maui.Views;

public partial class WaitingPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly WaitingViewModel _viewModel;
    private readonly SyncService _syncService;

    public FileResult FotoParaEnviar
    {
        get => _viewModel.FotoParaEnviar;
        set => _viewModel.FotoParaEnviar = value;
    }

    public WaitingPage(IServiceProvider serviceProvider, 
        HttpClienteService httpClienteService, 
        SyncService syncService)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _viewModel = new WaitingViewModel(httpClienteService);
        _syncService = syncService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            await DisplayAlert("Sin conexión", "No puedes realizar la búsqueda sin Internet. Intenta más tarde.", "OK");
            await Navigation.PopAsync();
            return;
        }


        await _syncService.SincronizarTodoAsync();

        if (_viewModel.FotoParaEnviar == null)
        {
            await DisplayAlert("Error", "No se encontró ninguna imagen para procesar.", "OK");
            await Navigation.PopAsync();
            return;
        }

        var stream = await _viewModel.FotoParaEnviar.OpenReadAsync();
        imgCargando.Source = ImageSource.FromStream(() => stream);

        string rutaImagen = await GuardarImagenLocalAsync(_viewModel.FotoParaEnviar);
        var resultado = await _viewModel.ProcesarImagen();

        if (resultado != null)
        {
            var detailViewModel = _serviceProvider.GetRequiredService<DetailViewModel>();
            detailViewModel.rutaImagenLocal = rutaImagen;

            var detailPage = new DetailPage(_serviceProvider, detailViewModel);
            detailPage.SetResultado(resultado);

            await Navigation.PushAsync(detailPage);
        }
    
        else
        {
            await DisplayAlert("Error", "No se pudo analizar la imagen.", "OK");
            await Navigation.PopAsync();
        }
    }

    private async Task<string> GuardarImagenLocalAsync(FileResult foto)
    {
        if (foto == null) return null;

        string nombreArchivo = $"img_{DateTime.Now.Ticks}.jpg";
        string rutaLocal = Path.Combine(FileSystem.AppDataDirectory, nombreArchivo);

        using var streamEntrada = await foto.OpenReadAsync();
        using var streamSalida = File.OpenWrite(rutaLocal);
        await streamEntrada.CopyToAsync(streamSalida);

        return rutaLocal;
    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
    }

    private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess != NetworkAccess.Internet)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await DisplayAlert("Conexión perdida", "Se perdió la conexión a Internet. Regresando...", "OK");
                await Navigation.PopAsync();
            });
        }
    }

}   

