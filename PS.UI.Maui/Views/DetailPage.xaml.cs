using Microsoft.Extensions.DependencyInjection;
using PS.Core.Models;
using PS.UI.Maui.ViewModels;

namespace PS.UI.Maui.Views;

public partial class DetailPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DetailViewModel _viewModel;

    public DetailPage(IServiceProvider serviceProvider, DetailViewModel viewModel)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _viewModel = viewModel;
        _viewModel.MostrarAlerta = async (mensaje) =>
        {
            await DisplayAlert("Error", mensaje, "OK");
        };
    }

    private void btnKeep_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Views.HistoryPage());
    }

    private void btnShare_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new Views.LoadPage());
    }

    private void btnSearch_Clicked(object sender, EventArgs e)
    {
       // Navigation.PushAsync(new Views.LoadPage());
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var mascota = new MascotaModel
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = lblNombreRaza.Text,
                Especie = lblEspecie.Text,
                Origen = lblOrigen.Text,

                CaracteristicasFisicasTamano = lblTamanio.Text,
                CaracteristicasFisicasPeso = lblPeso.Text,
                CaracteristicasFisicasEsperanzaVida = lblEsperanzaVida.Text,
                CaracteristicasFisicasPelaje = lblPelaje.Text,

                AlimentacionTipoRecomendada = lblRecomendada.Text,
                AlimentacionPorciones = lblPorciones.Text,
                AlimentacionFrecuencia = lblFrecuencia.Text,

                CuidadosEspecialesEjercicio = lblEjercicio.Text,
                CuidadosEspecialesSocializacion = lblSocializacion.Text,

                EnfermedadNombre = lblNombreEnfermedad.Text,
                EnfermedadDescripcion = lblDescripcionEnfermedad.Text,
                EnfermedadPrevencion = lblPrevencionEnfermedad.Text,

                UrlImage = "img.jpg", // Por ahora fija o l�gica personalizada
                UsuarioId = "Id-01", // Reemplazar por el usuario actual
                Estado = true,
                Sincronizado = false
            };

            await _viewModel.GuardarMascotaAsync(mascota);

            await DisplayAlert("Guardado", "Mascota guardada correctamente", "OK");

            var nextPage = _serviceProvider.GetRequiredService<HistoryPage>();
            await Navigation.PushAsync(nextPage);
            // Navigation.PushAsync(new Views.HistoryPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurri� un error: {ex.Message}", "OK");
        }
    }
}