using PS.Core.Models;
using PS.UI.Maui.ViewModels;

namespace PS.UI.Maui.Views;

public partial class DetailReadPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DetailReadViewModel _viewModel;

    public DetailReadPage(IServiceProvider serviceProvider, DetailReadViewModel viewModel)
	{
		InitializeComponent();
        _serviceProvider = serviceProvider;
        _viewModel = viewModel;
    }

    private async void btnRegresar_Clicked(object sender, EventArgs e)
    {
       var nextPage = _serviceProvider.GetRequiredService<HistoryPage>();
       await Navigation.PushAsync(nextPage);
    }

    private async void btnSearch_Clicked(object sender, EventArgs e)
    {
        var nextPage = _serviceProvider.GetRequiredService<LoadPage>();
        await Navigation.PushAsync(nextPage);
    }

    public async void CargarMascota(MascotaModel mascota)
    {
        lblNombreRaza.Text = mascota.Nombre;
        lblEspecie.Text = mascota.Especie;
        lblOrigen.Text = mascota.Origen;

        lblTamanio.Text = mascota.CaracteristicasFisicasTamano;
        lblPeso.Text = mascota.CaracteristicasFisicasPeso;
        lblEsperanzaVida.Text = mascota.CaracteristicasFisicasEsperanzaVida;
        lblPelaje.Text = mascota.CaracteristicasFisicasPelaje;

        lblRecomendada.Text = mascota.AlimentacionTipoRecomendada;
        lblPorciones.Text = mascota.AlimentacionPorciones;
        lblFrecuencia.Text = mascota.AlimentacionFrecuencia;

        lblEjercicio.Text = mascota.CuidadosEspecialesEjercicio;
        lblSocializacion.Text = mascota.CuidadosEspecialesSocializacion;

        var enfermedadesComunes = await _viewModel.GetByIdMascota(mascota.Id);

        if (enfermedadesComunes == null || !enfermedadesComunes.Any())
        {
            await DisplayAlert("Aviso", "La mascota no tiene enfermedades registradas.", "OK");
        }
        else
        {
            cvEnfermedadesComunes.ItemsSource = enfermedadesComunes;
        }

        imgResultado.Source = string.IsNullOrEmpty(mascota.RutaImagenLocal)
            ? "imgvacia.png"
            : mascota.RutaImagenLocal;
    }
}