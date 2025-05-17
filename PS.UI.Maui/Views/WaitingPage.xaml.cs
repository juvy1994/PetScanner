
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

    public FileResult FotoParaEnviar
    {
        get => _viewModel.FotoParaEnviar;
        set => _viewModel.FotoParaEnviar = value;
    }

    public WaitingPage(IServiceProvider serviceProvider, HttpClienteService httpClienteService)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _viewModel = new WaitingViewModel(httpClienteService);
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


        if (_viewModel.FotoParaEnviar == null)
        {
            await DisplayAlert("Error", "No se encontró ninguna imagen para procesar.", "OK");
            await Navigation.PopAsync();
            return;
        }

        var stream = await _viewModel.FotoParaEnviar.OpenReadAsync();
        imgCargando.Source = ImageSource.FromStream(() => stream);

        var resultado = await _viewModel.ProcesarImagen();

        if (resultado != null)
        {
            var nextPage = _serviceProvider.GetRequiredService<DetailPage>();
            nextPage.SetResultado(resultado);
            await Navigation.PushAsync(nextPage);
        }
        else
        {
            await DisplayAlert("Error", "No se pudo analizar la imagen.", "OK");
            await Navigation.PopAsync();
        }
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

